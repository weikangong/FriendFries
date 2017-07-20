using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//give this component to player objects meant to be swiped
//object must have rigidbody component

public class PlayerSwipe : MonoBehaviour {

	Rigidbody2D rb;
	//public float upForce;
	//public float downForce;
	//public float leftForce;
	//public float rightForce;

	public float multiplierForceB;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Swipe(float xForce, float yForce, float multiplierForceA) {
		rb.AddForce (new Vector2 (xForce * multiplierForceA * multiplierForceB, yForce * multiplierForceA * multiplierForceB));
	}

/*	public void SwipeUp(float multiplier){
		rb.AddForce (new Vector2 (0, upForce*multiplier));
	}

	public void SwipeDown(float multiplier){
		rb.AddForce (new Vector2 (0, -downForce*multiplier));
	}

	public void SwipeLeft(float multiplier){
		rb.AddForce (new Vector2 (-leftForce*multiplier, 0));
	}

	public void SwipeRight(float multiplier){
		rb.AddForce (new Vector2 (rightForce*multiplier, 0));
	}
*/
}
