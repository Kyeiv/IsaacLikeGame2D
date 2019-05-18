using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour {
	Vector3 moveJump = Vector2.zero;
	float horMove, vertMove;
    GameObject player;//added
    public GameObject enter; //added
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");//added
        enter = GameObject.FindGameObjectWithTag("DoorTrigger");//added
        SheetAssigner SA = FindObjectOfType<SheetAssigner>();
		Vector2 tempJump = SA.roomDimensions + SA.gutterSize;
		moveJump = new Vector3(tempJump.x, tempJump.y, 0); //distance b/w rooms: to be used for movement
	}
	void Update()
	{
		if ((Input.GetKeyDown("up") || Input.GetKeyDown("s") || 
			Input.GetKeyDown("a") || Input.GetKeyDown("d"))
            &&enter.transform.position.x==player.transform.position.x//added
            && enter.transform.position.y == player.transform.position.y)//added //if any 'wasd' key is pressed
        {
			horMove = System.Math.Sign(Input.GetAxisRaw("Horizontal"));//capture input
			vertMove = System.Math.Sign(Input.GetAxisRaw("Vertical"));
			Vector3 tempPos = transform.position;
			tempPos += Vector3.right * horMove * moveJump.x; //jump bnetween rooms based opn input
			tempPos += Vector3.up * vertMove * moveJump.y;
            
            player.transform.position = tempPos;//added
            transform.position = tempPos;
		}
	}
}
