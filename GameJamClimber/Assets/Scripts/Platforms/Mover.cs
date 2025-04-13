using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;
    public float speed = 2f;

    void FixedUpdate()
    {
        if (transform.position == end){
            Vector3 temp = end;
            end = start;
            start = end;
        }

        transform.Translate(, start.y, start.z)
    }
}
