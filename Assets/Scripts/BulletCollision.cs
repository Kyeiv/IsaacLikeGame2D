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
        if (other.gameObject.CompareTag("Enemy")){
            EnemyMeeleAI script = other.gameObject.GetComponent<EnemyMeeleAI>();
            script.currentState = EnemyState.Die;
        }

        Debug.Log("bullet collision");
    }
}
