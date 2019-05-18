using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float velX = 0f;
    public float velY = 0f;
    public float speed = 100f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (velX != 0 && velY != 0)
        {
            velY /= 1.44f;
            velX /= 1.44f;

        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }


}
