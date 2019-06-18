using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BulletCollision : MonoBehaviour
{
    public GameObject explosionGO;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("HealPotion"))
            return;

        UtilityBehaviors scoreScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>();
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Enemy")){
            PlayExplosion();
            EnemyMeeleAI script = other.gameObject.GetComponent<EnemyMeeleAI>();
            script.enemy_lives--;
            Debug.Log("decreement");
            if (script.enemy_lives <= 0)
            {
                scoreScript.addScore(1);
                script.currentState = EnemyState.Die;
            }
        } else if (other.gameObject.CompareTag("Nerve")) {
            PlayExplosion();
            EnemyDistanceAI script = other.gameObject.GetComponent<EnemyDistanceAI>();
            script.enemy_lives--;
            Debug.Log("decreement");
            if (script.enemy_lives <= 0)
            {
                scoreScript.addScore(1);
                script.currentState = EnemyState.Die;
            }
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            PlayExplosion();
            BSAI script = other.gameObject.GetComponent<BSAI>();
            script.enemy_lives--;
            Debug.Log("decreement");
            if (script.enemy_lives <= 0)
            {
                scoreScript.addScore(100);
                script.currentState = EnemyState.Die;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }


        // Debug.Log("bullet collision");
    }

    private void PlayExplosion() {
        GameObject explosion = (GameObject)Instantiate(explosionGO);
        explosion.transform.position = transform.position;
    }
}
