using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        //ScoreScript scoreScript = GameObject.FindGameObjectWithTag("score").GetComponent<ScoreScript>();
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
            return;
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Enemy")){
            EnemyMeeleAI script = other.gameObject.GetComponent<EnemyMeeleAI>();
            script.enemy_lives--;
            Debug.Log("decreement");
            if (script.enemy_lives <= 0)
            {
               // scoreScript.score++;
                script.currentState = EnemyState.Die;
            }
        } else if (other.gameObject.CompareTag("Nerve")) {
            EnemyDistanceAI script = other.gameObject.GetComponent<EnemyDistanceAI>();
            script.enemy_lives--;
            Debug.Log("decreement");
            if (script.enemy_lives <= 0)
            {
               // scoreScript.score++;
                script.currentState = EnemyState.Die;
            }
        }

        Debug.Log("bullet collision");
    }
}
