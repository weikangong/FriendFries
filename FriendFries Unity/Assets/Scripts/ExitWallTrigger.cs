﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checks for num of fries left in spawner
// will change to next scene if goNextLvl = true and friesLeft = 0
// destroys fries on contact with objects 
public class ExitWallTrigger : MonoBehaviour {
	public bool goNextLvl;
	public bool isLastLvl;
	public bool isFirstLvl;

	bool allTouchedExitWall = false;
	public float waitTime;
	public int fontSize;

	bool showMessage = false;
	public string nextPlayerMessage;

	public GameObject nextLvl;

	// Destroys objects tagged with "potato" when they enter the trigger area
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Collision with exit wall detected: " + other.gameObject.name);

		if (other.gameObject.tag == "Potato") {
			Destroy (other.gameObject);
		}
	}

	public void Update() {
		if (!isFirstLvl) {
			GameObject frySpawner = GameObject.Find ("frySpawner");
			SpawnObjects fryScript = frySpawner.GetComponent<SpawnObjects> ();

			if (fryScript.friesLeft <= 0) {
				allTouchedExitWall = true;
			}
		}

		if (isFirstLvl) {
			GameObject fryspawner = GameObject.Find ("SwipeTester");
			SwipeFunctions fryScript = fryspawner.GetComponent<SwipeFunctions> ();

			if (fryScript.friesLeft <= 0) {
				allTouchedExitWall = true;
			}
		}

		// Changes scene
		if (goNextLvl && allTouchedExitWall) {
			StartCoroutine ("WaitToLoad");
		}
	}

	// Loads next scene after a while
	IEnumerator WaitToLoad() {
		yield return new WaitForSecondsRealtime (2);
		showMessage = true;
		yield return new WaitForSecondsRealtime (waitTime);
		if (isLastLvl) {
			nextLvl.GetComponent<LvlManager> ().endGame ();
		} else {
			nextLvl.GetComponent<LvlManager> ().goNextLvl ();
		}
	}

    //--------------------------------------------------------------------------------------------//
    // Below is mostly used for debugging, can just remove or comment out
    void OnGUI() {
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = fontSize;

		if (showMessage) {
			GUI.Label (new Rect (Screen.width/2 - 100, Screen.height/2 + 50, 200, 100), nextPlayerMessage, centeredStyle);
		}
	}
}
