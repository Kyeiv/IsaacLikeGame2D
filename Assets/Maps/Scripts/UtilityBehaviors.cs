using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UtilityBehaviors : MonoBehaviour {

    private int score = 0;

    void Update () {
		if (Input.GetKeyDown("r")){//reload scene, for testing purposes
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

    public int getScore()
    {
        return score;
    }

    public void addScore(int sc)
    {
        score += sc;
    }

    public void resetScore()
    {
        score = 0;
    }
}
