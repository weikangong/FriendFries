using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script defines all the score 
// functions and displays score UI

public class ScoreSystem : MonoBehaviour {
	public Text scoreText;
	public static int currScore = 0;
	
	// Update is called once per frame
	void Update () {
		setScoreText ();
	}

	// Add points to the total score
	public void updateScore (int addScore) {
		currScore = currScore + addScore;
		Debug.Log("New Score: " + currScore);
	}

	// Resets score to 0
	public void resetScore() {
        currScore = 0;
		Debug.Log("Score resets to 0");
	}
		
	void setScoreText() {
		scoreText.text = currScore.ToString();
	}
}
