using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTp : MonoBehaviour
{

    public Vector2 shift;
    float horMove, vertMove;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.position += new Vector3(shift.x, shift.y, 0f);
            
            {
                Camera mycam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

                SheetAssigner SA = FindObjectOfType<SheetAssigner>();
                Vector2 tempJump = SA.roomDimensions + SA.gutterSize;
                Vector3 moveJump = new Vector3(tempJump.x, tempJump.y, 0); //distance b/w rooms: to be used for movement


                horMove = System.Math.Sign(shift.x);//capture input
                vertMove = System.Math.Sign(shift.y);
                Vector3 tempPos = mycam.transform.position;
                tempPos += Vector3.right * horMove * moveJump.x; //jump bnetween rooms 
                tempPos += Vector3.up * vertMove * moveJump.y;


                mycam.transform.position = new Vector3(tempPos.x, tempPos.y, mycam.transform.position.z);
            }

            {
                GameObject pos = GameObject.FindGameObjectWithTag("pos");
                RectTransform rect = pos.GetComponent<RectTransform>();
               // Vector3 rectPosition = rect.position;
                rect.position += new Vector3(shift.x/4.2f, shift.y/4.8f, 0f);
            }
        }
    }
}
