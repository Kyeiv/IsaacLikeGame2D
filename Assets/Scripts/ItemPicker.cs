using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("HealPotion") && other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            playerHealth.heal(value);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("SpeedUp") && other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            playerMovement.speed += value;
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Shield") && other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            playerHealth.increaseResistance((float)value / 100.0f);
            Destroy(gameObject);
        }
    }
}
