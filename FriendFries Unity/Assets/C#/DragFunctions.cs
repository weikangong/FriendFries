using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dragging on screen will cause player object to move in that direction
//any direction works

public class DragFunctions : MonoBehaviour {

	public GameObject Player;
	public float dragSpeed;
	bool cheeseTouched = false;

	public Rigidbody rb;
	public ParticleSystem cheeseEmit;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		cheeseEmit = gameObject.GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Moved) {

				//check if object is touched
				Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				if(Physics2D.Raycast(test, Input.GetTouch(0).position).collider.tag == "Cheese") {
					cheeseTouched = true;
					Debug.Log("Cheese touched");
				} 

				if (cheeseTouched) {
					Debug.Log ("drag detected");
					drag (touch, dragSpeed);
				}
			}

			if (touch.phase == TouchPhase.Ended) {
				cheeseTouched = false;
			}
		}

		if (rb.velocity.magnitude > 0) {
			cheeseEmit.Emit (1);
		}
		if (rb.velocity.magnitude <= 0) {
			cheeseEmit.Stop ();
		}

	}

	void drag(Touch touch, float dragSpeed) {
		Player.GetComponent<PlayerDrag> ().Drag (touch, dragSpeed);
	}
		
}