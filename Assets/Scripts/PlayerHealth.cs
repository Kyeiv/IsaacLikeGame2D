using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	public int health;
    private float resistance = 0.0f;
    UtilityBehaviors scoreScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>();


    public void TakeDamage(int damage)
	{
		health -= (damage - (int)((float)damage * resistance));
        if (health <= 0) {
            scoreScript.setBossKilled(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Debug.Log("Health = " + health.ToString());
	}

    public void heal(int value)
    {
        health += value;
        if (health > 100)
            health = 100;
        Debug.Log("Uleczyłem się o " + value.ToString() + " . Teraz mam hp: " + health.ToString());
    }

    public void increaseResistance(float value)
    {
        resistance += value;

        if (resistance > 0.5f)
            resistance = 0.5f;
    }
}
