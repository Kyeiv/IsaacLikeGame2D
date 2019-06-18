using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text text;
    public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>().getScore();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>().resetScore();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().resetTimer();
        text = gameObject.GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Your score " + score.ToString();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().resetTimer();
    }
}
