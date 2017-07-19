using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseGrate : MonoBehaviour {

	public bool emitCheese = false;

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("Collision Detected");

		if (other.gameObject.tag == "Cheese") {
			Debug.Log ("Cheese has entered Grater");
			emitCheese = true;
		} 

	}

	void OnTriggerStay2D(Collider2D other) {
		emitCheese = false;
	}
	void OnTriggerExit2D (Collider2D other) {
		emitCheese = false;
	}
}
