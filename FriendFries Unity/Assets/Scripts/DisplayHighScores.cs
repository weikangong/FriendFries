using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script displays the top 8 high scores on HighScoreScene
public class DisplayHighScores : MonoBehaviour {
    List<Scores> highScore;
    public Text[] teamName;
    public Text[] score;

	void Start () {
        highScore = HighScoreManager._instance.GetHighScore();
        Debug.Log(highScore.Count);
        for(int i = 0; i <= highScore.Count; i++) {
            if (highScore[i].name == "") teamName[i].text = (i+1) + ". No Name";
            else teamName[i].text = (i+1) + ". " + highScore[i].name;
            score[i].text = highScore[i].score.ToString();
        }
	}
}
