using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add to fry container
//add points for every fry caught in trigger collider

public class CountCaughtFries : MonoBehaviour {

	public GameObject Score;
	public int points = 30;

	int caughtCount = 0;

	//add points for every fry caught in trigger collider
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
		
}
