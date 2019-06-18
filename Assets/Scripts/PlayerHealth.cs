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
}
