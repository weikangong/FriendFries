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
		
}
