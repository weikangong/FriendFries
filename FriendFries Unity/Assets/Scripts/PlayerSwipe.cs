using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//give this component to player objects meant to be 
// swiped. Object must have rigidbody component
public class PlayerSwipe : MonoBehaviour {
	Rigidbody2D rb;

	public float multiplierForceB;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}

	public void Swipe(float xForce, float yForce, float multiplierForceA) {
		rb.AddForce (new Vector2 (xForce * multiplierForceA * multiplierForceB, yForce * multiplierForceA * multiplierForceB));
	}

}
