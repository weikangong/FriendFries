using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCounter : MonoBehaviour {

	public GameObject Score;
	public int points = 1; //this is points added per particle after enough flavor

	bool enoughFlavour = false;
	public float minFlavour;
	int colCount = 0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (colCount >= minFlavour) {
			enoughFlavour = true;
			//adds points for every successful flavor added
			Score.GetComponent<ScoreSystem> ().updateScore (points);
		}
	}

	void OnParticleCollision(GameObject other) {
		Debug.Log ("Collision Detected");
		colCount ++;
		Debug.Log ("no. of collisions: " + colCount);
	}

/*	void OnGUI() {
		//this is mostly only for debug
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = 45;

		if (enoughFlavour) {
			GUI.Label (new Rect (Screen.width/2 - 100, Screen.height/2 + 50, 200, 100), "enough", centeredStyle);
		}
	} */

}
