using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTp : MonoBehaviour
{

    public Vector2 shift;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.position += new Vector3(shift.x, shift.y, 0f);
        }
    }
}
