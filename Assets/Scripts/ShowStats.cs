using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{
    
    UtilityBehaviors stats;
    Timer timer;
    Text text;
    GameObject player;
    
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>();
        timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();
        text = GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            
        text.text = "Score: " + stats.getScore() + "       Seconds: " + (int)timer.getTime() + "       Speed: " + player.GetComponent<PlayerMovement>().speed +
                "       Resistance: " + (int)(player.GetComponent<PlayerHealth>().getResistance() * 100) + "       Attack: " + 
                (stats.additionalDamage + 1);
    }
}
