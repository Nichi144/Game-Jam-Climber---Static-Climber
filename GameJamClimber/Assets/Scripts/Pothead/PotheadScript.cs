using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PotheadScript : MonoBehaviour
{
    private Rigidbody2D PotHeadBody;
    private float horizontalMove = 10f;
    public bool is_jump;
    public bool is_grounded;
    private Animator animator;
    SpriteRenderer spriteRenderer;

    bool jumper;
    bool stop;

    // Start is called before the first frame update
    void Start()
    {
        stop = true;
        jumper = false;
        PotHeadBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PotHeadBody.gravityScale = 2f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (stop){
            horizontalMove = Input.GetAxis("Horizontal");
        } else {
            horizontalMove = 0;
        }
        animator.SetBool("Run", horizontalMove != 0);
        animator.SetBool("JumpEnd", is_grounded);
        is_jump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W);

        animator.SetFloat("VerticalMove", PotHeadBody.velocity.y);
        if (is_jump && is_grounded){
            animator.SetBool("JumpLaunch", true);
            StartCoroutine(WaitAndJump());
        } 
        if (jumper){
            jumper = false;
            PotHeadBody.AddForce(Vector2.up * 15f,ForceMode2D.Impulse);
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
        Debug.Log("enter");
        stop = false;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("JumpLaunch", false);
        Debug.Log("Exit");
        jumper = true;
        yield return null;
        
    }
}