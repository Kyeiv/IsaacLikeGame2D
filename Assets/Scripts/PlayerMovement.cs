using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;

    public GameObject bulletToRight, bulletToLeft, bulletToUp, bulletToDown;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0;
    bool facingRight = false;
    bool facingLeft = false;
    bool facingUp = false;
    bool facingDown = false;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        onArrowKeys();

        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            onWsadKeys();
        }
	}

    void onArrowKeys(){
        float horizontalAxis = 0,
              verticalAxis   = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("KeyCode.UpArrow");
            verticalAxis += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("KeyCode.LeftArrow");
            horizontalAxis -= 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("KeyCode.DownArrow");
            verticalAxis -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("KeyCode.RightArrow");
            horizontalAxis += 1;
        }

        Vector2 movement_vector = new Vector2(horizontalAxis, verticalAxis);
        handleAnimation(movement_vector);
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
    }

    void onWsadKeys()
    {
        float horizontalAxis = 0,
              verticalAxis = 0;

        bool shootingLeft = false,
             shootingRight = false,
             shootingUp = false,
             shootingDown = false;

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("KeyCode.W");
            verticalAxis += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("KeyCode.A");
            horizontalAxis -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("KeyCode.S");
            verticalAxis -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("KeyCode.D");
            horizontalAxis += 1;
        }

        if (horizontalAxis != 0)
        {
            shootingRight = horizontalAxis > 0;
            shootingLeft = !shootingRight;
        }
        if (verticalAxis != 0)
        {
            shootingUp = verticalAxis > 0;
            shootingDown = !shootingUp;
        }

        bulletPos = transform.position;

        if (shootingRight)
        {
            bulletPos += new Vector2(+1f, 0f);
            Instantiate(bulletToRight, bulletPos, Quaternion.identity);
        }
        else if (shootingLeft)
        {
            bulletPos += new Vector2(-1f, 0f);
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
        }
        else if (shootingUp)
        {
            bulletPos += new Vector2(0f, +1f);
            Instantiate(bulletToUp, bulletPos, Quaternion.identity);
        }
        else if (shootingDown)
        {
            bulletPos += new Vector2(0f, -1f);
            Instantiate(bulletToDown, bulletPos, Quaternion.identity);
        }

        /*
        if(shootingDown || shootingLeft || shootingUp || shootingDown)
        {
            Instantiate(bulletToRight, bulletPos, Quaternion.identity);
        }
        */
    }

    void handleAnimation(Vector2 movement_vector){
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
            if (movement_vector.x > 0)
            {
                facingRight = true;
                facingLeft = false;
                facingUp = false;
                facingDown = false;
            }
            else if (movement_vector.x < 0)
            {
                facingRight = false;
                facingLeft = true;
                facingUp = false;
                facingDown = false;
            }
            else if (movement_vector.y > 0)
            {
                facingRight = false;
                facingLeft = false;
                facingUp = true;
                facingDown = false;
            }
            else
            {
                facingRight = false;
                facingLeft = false;
                facingUp = false;
                facingDown = true;
            }
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
    }
}
