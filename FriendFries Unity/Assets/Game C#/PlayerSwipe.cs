using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//give this component to player objects meant to be swiped
//object must have rigidbody component

public class PlayerSwipe : MonoBehaviour {

	Rigidbody2D rb;
	public float upForce;
	public float downForce;
	public float leftForce;
	public float rightForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwipeUp(){
		rb.AddForce (new Vector2 (0, upForce));
	}

	public void SwipeDown(){
		rb.AddForce (new Vector2 (0, -downForce));
	}

	public void SwipeLeft(){
		rb.AddForce (new Vector2 (-leftForce, 0));
	}

	public void SwipeRight(){
		rb.AddForce (new Vector2 (rightForce, 0));
	}
}
