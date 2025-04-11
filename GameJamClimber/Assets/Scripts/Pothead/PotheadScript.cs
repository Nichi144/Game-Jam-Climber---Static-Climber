using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotheadScript : MonoBehaviour
{
    public Rigidbody2D PotHeadBody;
    public BoxCollider2D collider;
    private float horizontalMove;
    public bool is_free;
    // Start is called before the first frame update
    void Start()
    {
        is_free = false;
       collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        PotHeadBody.velocity = new Vector3(horizontalMove * 10f,PotHeadBody.velocity.y, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            PotHeadBody.isKinematic = true;
            is_free = false;
        }   
        if (collision.gameObject.CompareTag("Foot")){
            PotHeadBody.isKinematic = true;
            is_free = false;
        }
    }
}
