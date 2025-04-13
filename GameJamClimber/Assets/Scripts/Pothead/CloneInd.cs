using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneInd : MonoBehaviour
{
    private Rigidbody2D PotHeadBody;
    private float horizontalMove = 10f;
    public bool is_jump;
    public bool is_grounded;
    private Animator animator;
    SpriteRenderer spriteRenderer;
    public List<float> values;
    public List<bool> jumps;
    bool jumper;
    bool stop;
    private int pos = 0;
    public int lenght;
    public GameObject death;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (0, -1.5f,0);
        values = PotheadScript.values;
        jumps = PotheadScript.jumps;
        stop = true;
        PotHeadBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PotHeadBody.gravityScale = 2f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (death.GetComponent<Death>().death == true){
            pos = 0;
        }
        // Debug.Log(pos);
        if (stop){
            if (pos < values.Count){
                horizontalMove = values[pos];
                is_jump = jumps[pos];
                pos++;
            } else {
                horizontalMove = 0;
                is_jump = false;
            }
        } else {
            horizontalMove = 0;
        }

        animator.SetBool("Run", horizontalMove != 0);
        animator.SetBool("JumpEnd", is_grounded);
        animator.SetFloat("VerticalMove", PotHeadBody.velocity.y);
        
        if (is_jump && is_grounded){
            animator.SetBool("JumpLaunch", true);
            StartCoroutine(WaitAndJump());
        } 
        if (jumper && is_grounded){
            jumper = false;
            Debug.Log("jump");
            PotHeadBody.AddForce(Vector2.up * 7.5f,ForceMode2D.Impulse);
            stop = true;
        }
    }
    
    void FixedUpdate()
    {
        PotHeadBody.velocity = new Vector3(horizontalMove * 3.5f,PotHeadBody.velocity.y, 0);
        if (horizontalMove < 0){
            spriteRenderer.flipX = true;
        }
        if (horizontalMove > 0){
            spriteRenderer.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StableGround")){
            is_grounded = true;
        }   
        if (collision.gameObject.CompareTag("UnstableGround")){
            is_grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StableGround")){
            is_grounded = false;
        }   
        if (collision.gameObject.CompareTag("UnstableGround")){
            is_grounded = false;
        }
    }
    private IEnumerator WaitAndJump (){
        stop = false;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("JumpLaunch", false);
        jumper = true;
        yield return null;
        
    }
}
