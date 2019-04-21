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

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
            if (movement_vector.x > 0){
                facingRight = true;
                facingLeft = false;
                facingUp = false;
                facingDown = false;
            } else if (movement_vector.x < 0){
                facingRight = false;
                facingLeft = true;
                facingUp = false;
                facingDown = false;
            } else if(movement_vector.y > 0){
                facingRight = false;
                facingLeft = false;
                facingUp = true;
                facingDown = false;
            } else {
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

        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            fire();
        }
	}

    void fire() {
        if (facingRight)
            bulletPos = transform.position + new Vector3(-0.5f, 0f, 0f);
        else if (facingLeft)
            bulletPos = transform.position + new Vector3(0.5f, 0f, 0f);

        bulletPos = transform.position;

        if (facingRight) {
            bulletPos += new Vector2(+1f, 0f);
            Instantiate(bulletToRight, bulletPos, Quaternion.identity);
        } else if (facingLeft){
            bulletPos += new Vector2(-1f, 0f);
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
        } else if (facingUp){
            bulletPos += new Vector2(0f, +1f);
            Instantiate(bulletToUp, bulletPos, Quaternion.identity);
        } else { 
            bulletPos += new Vector2(0f, -1f);
            Instantiate(bulletToDown, bulletPos, Quaternion.identity);
        }
    }
}
