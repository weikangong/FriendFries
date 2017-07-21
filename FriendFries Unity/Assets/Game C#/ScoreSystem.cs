using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	public Text scoreText;

	public static int currScore = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		setScoreText ();
	}

	public void updateScore (int addScore) {
		currScore = currScore + addScore;
		Debug.Log ("New Score: " + currScore);
	}

	void setScoreText(){
		scoreText.text = currScore.ToString ();
	}
}
