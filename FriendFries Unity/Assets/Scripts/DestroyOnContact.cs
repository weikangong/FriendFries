using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroy objects on trigger enter
public class DestroyOnContact : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Collision detected: " + other.gameObject.name);

		if (other.gameObject.tag == "Potato") {
			Destroy (other.gameObject);
			Debug.Log (other.gameObject.name + "deleted");
		}

	}

}
