using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCaughtFries : MonoBehaviour {

	public GameObject Score;
	public int points = 30;

	int caughtCount = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Collision Detected");

		if (other.gameObject.tag == "Potato") {
			Destroy (other.gameObject);
			caughtCount ++;
			//adds points for every successful catch
			Score.GetComponent<ScoreSystem> ().updateScore (points);
		}

		Debug.Log ("no. of collisions: " + caughtCount);
	}

/*	void OnGUI() {
		//this is mostly only for debug
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = 45;
		string message = "caught: " + caughtCount;

		GUI.Label (new Rect (Screen.width/2 - 100, Screen.height/2 + 50, 200, 100), message, centeredStyle);


	} */
}
