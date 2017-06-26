using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//gives whatever object using this script the ability to move left or right
//depending on which part the screen is touched.
public class MovingLeftRightByTouch : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		float LeftRight = 0;

		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);

			// touch x position is bigger than half of the screen, moving right
			if (Input.GetTouch (0).position.x > Screen.width / 2) {
				Debug.Log ("Right side screen touch detected");
				LeftRight = 1;
			}
			// touch x position is smaller than half of the screen, moving left
			else if (Input.GetTouch (0).position.x < Screen.width / 2) {
				Debug.Log ("Left side screen touch detected");
				LeftRight = -1;
			}

			if (touch.phase == TouchPhase.Ended) {
				rb.velocity = Vector3.zero;
			}
		}

		Vector3 Movement = new Vector3 ( LeftRight, 0, 0);

		rb.AddForce(Movement * speed);
	}

}
