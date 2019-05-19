using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Vector2 speedVector = Vector2.zero;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (speedVector.x != 0 && speedVector.y != 0)
        {
            speedVector /= 1.44f;
        }

        rb.velocity = speedVector;
    }
}
