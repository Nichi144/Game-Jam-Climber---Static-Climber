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
    InputActions input;
    private Animator animator;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        input = new InputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        PotHeadBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        animator.SetBool("Run", horizontalMove != 0);
        animator.SetBool("JumpEnd", is_grounded);
        if (horizontalMove < 0){
            spriteRenderer.flipX = true;
        }
        if (horizontalMove > 0){
            spriteRenderer.flipX = false;
        }
        animator.SetFloat("VerticalMove", PotHeadBody.velocity.y);
        if (is_jump && is_grounded){
            PotHeadBody.AddForce(Vector2.up * 50f);
            StartCoroutine(Wait());
            // is_jump = false;
        }
    }
    
    

    void FixedUpdate()
    {
        PotHeadBody.velocity = new Vector3(horizontalMove * 10f,PotHeadBody.velocity.y, 0);
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



    #region Input

    void OnEnable()
    {
        input.Enable();
        input.WASD.W.performed += OnMyActionPerformed;
        input.WASD.Space.performed += OnMyActionPerformed;
    }

    void OnDisable()
    {
        input.Disable();
        input.WASD.Space.performed -= OnMyActionPerformed;
    }

    private void OnMyActionPerformed(InputAction.CallbackContext context)
    {
        is_jump = true;
        StartCoroutine(Wait());
    } 

    private IEnumerator Wait(){
        yield return new WaitForSeconds(0.1f);
        is_jump = false;
    }

    #endregion Input

}