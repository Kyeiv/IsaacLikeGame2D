using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
            return;
        Destroy(gameObject);
        Destroy(other.gameObject);
        Debug.Log("bullet collision");
    }
}
