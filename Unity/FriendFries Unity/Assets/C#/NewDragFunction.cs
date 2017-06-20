using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dragging on screen will cause player object to move in that direction
//any direction works

public class NewDragFunction : MonoBehaviour {

	public GameObject Player;
	public float dragSpeed;
	bool cheeseTouched;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began) {
				//check if cheese touched
				Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				RaycastHit2D hit = Physics2D.Raycast (touchPos, Vector2.zero);
				if(hit != null && hit.collider.tag == "Cheese") {
					cheeseTouched = true;
					Debug.Log("Cheese touched");
				} 
			}

			if (touch.phase == TouchPhase.Moved) {

				if (cheeseTouched) {
					Debug.Log ("drag detected");
					drag (touch, dragSpeed);
				}
			}

			if (touch.phase == TouchPhase.Ended) {
				cheeseTouched = false;
			}
		}
	}

	void drag(Touch touch, float dragSpeed) {
		Player.GetComponent<PlayerDrag> ().Drag (touch, dragSpeed);
	}

}