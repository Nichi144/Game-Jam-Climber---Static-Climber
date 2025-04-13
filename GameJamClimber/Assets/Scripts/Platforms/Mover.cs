using System;
using Unity.Mathematics;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;
    private float dx = 0.05f;
    private float dy = 0.1f;
    void Start()
    {
        if (start.x - end.x == 0) {
            dx = 0f;
        }
         else if (start.x - end.x > 0){
            dx *= -1;
        }

        if (start.y - end.y == 0) {
            dy = 0f;
        }
         else if (start.y - end.y > 0){
            dy *= -1;
        }
    }
    void FixedUpdate()
    {     
        Debug.Log((end - transform.position).magnitude);
        if ((end -  transform.position).magnitude < 1){
            Debug.Log("switch");
            Vector3 temp = end;
            end = start;
            start = temp;
            Debug.Log (end.x);
            dx = -dx;
            dy = -dy;
        }

        transform.Translate(dx, dy, 0);
    }
}
