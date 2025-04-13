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
        if ((end -  transform.position).magnitude < 1){
            Vector3 temp = end;
            end = start;
            start = temp;
            dx = -dx;
            dy = -dy;
        }

        transform.Translate(dx, dy, 0);
    }
}
