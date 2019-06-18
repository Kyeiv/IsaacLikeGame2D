using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{
    
    UtilityBehaviors stats;
    Timer timer;
    Text text;
    
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>();
        timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();
        text = GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + stats.getScore() + "       Seconds: " + (int)timer.getTime();
    }
}
