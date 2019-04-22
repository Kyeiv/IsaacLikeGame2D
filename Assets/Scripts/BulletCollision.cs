using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
            Destroy(gameObject);
            Debug.Log("bullet collision");
    }
}
