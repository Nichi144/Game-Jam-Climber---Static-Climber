using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            // Add De-ja vu
            collision.gameObject.transform.position = new Vector3 (0f, -1.5f, 0f);
        }
    }
}
