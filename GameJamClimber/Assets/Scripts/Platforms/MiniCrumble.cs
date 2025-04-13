using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCrumble : MonoBehaviour
{
    [SerializeField] private int number_of_people;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (number_of_people >= 2){
            StartCoroutine(PCrumble());
        } 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")){
            number_of_people += 1;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")){
            number_of_people -= 1;
        }
    }

    private IEnumerator PCrumble () {
        animator.SetBool("crumble", true);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
        yield return null;
    }
}
