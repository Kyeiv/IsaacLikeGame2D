using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	public int health;

	public void TakeDamage(int damage)
	{
		health -= damage;
        if(health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Health = " + health.ToString());
	}

    public void heal(int value)
    {
        health += value;
        if (health > 100)
            health = 100;
    }
}
