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
        text = gameObject.GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Your score " + score.ToString();
    }
}
