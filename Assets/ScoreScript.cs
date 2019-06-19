using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text text;
    public int score=0;
    int time;
    bool CZY_BOSS_ZABITY;
    private Text textBoss;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>().getScore();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>().resetScore();
        time = (int)GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().getTime();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().resetTimer();
        text = gameObject.GetComponent<Text>();
        textBoss = GameObject.FindGameObjectWithTag("textBoss").GetComponent<Text>();
        CZY_BOSS_ZABITY = GameObject.FindGameObjectWithTag("GameController").GetComponent<UtilityBehaviors>().getBossKilled();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Your score " + (((300 - time) > 0 && CZY_BOSS_ZABITY) ? (score + 300 - time).ToString() : score.ToString());
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().resetTimer();
        if(CZY_BOSS_ZABITY)
            textBoss.text = "Congratulations! You killed boss!";
    }
}
