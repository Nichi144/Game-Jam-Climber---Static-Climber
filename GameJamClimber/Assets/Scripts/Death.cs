using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool death = false;
    void FixedUpdate()
    {
        death = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            death = true;
            collision.gameObject.transform.position = new Vector3 (0f, -1.5f, 0f);
        }
         if (collision.gameObject.CompareTag("Clone")){
            collision.gameObject.SetActive(false);
        }
    }
}
