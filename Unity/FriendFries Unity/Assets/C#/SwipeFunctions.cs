using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeFunctions : MonoBehaviour {

	public GameObject Player;
	public float maxTime; //max time of which exceeding is not counted as a swipe
	public float minSwipeDist; //min swipe distance of which not reaching is not counted as a swipe

	float startTime; //time when finger first touches screen
	float endTime; //time when finger is lifted off screen

	Vector3 startPos; //starting position on screen (touched screen)
	Vector3 endPos; //ending position on screen (lift finger)

	float swipeDist; //swipe distance btw two points
	float swipeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
		
			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				startTime = Time.time;
				startPos = touch.position;

			} 

			else if (touch.phase == TouchPhase.Ended) {
				endTime = Time.time;
				endPos = touch.position;

				//checking for swipe
				swipeDist = (endPos - startPos).magnitude;
				swipeTime = endTime - startTime;

				if ((swipeTime < maxTime) && (swipeDist > minSwipeDist)) {
					swipe ();
				}
			}
		}	
	}

	void swipe(){
		
		Vector2 distance = endPos - startPos;
		if (Mathf.Abs (distance.x) > Mathf.Abs (distance.y)) {
			Debug.Log ("Horizontal swipe detected");

			if (distance.x > 0) {
				Debug.Log ("Right swipe detected");
				Player.GetComponent<PlayerSwipe> ().SwipeRight ();
			}

			if (distance.x < 0) {
				Debug.Log ("Left swipe detected");
				Player.GetComponent<PlayerSwipe> ().SwipeLeft ();
			}
		}

		else if (Mathf.Abs (distance.y) > Mathf.Abs (distance.x)) {
			Debug.Log ("Vertical swipe detected");

			if (distance.y > 0) {
				Debug.Log ("Up swipe detected");
				Player.GetComponent<PlayerSwipe> ().SwipeUp ();
			}

			if (distance.y < 0) {
				Debug.Log ("Down swipe detected");
				Player.GetComponent<PlayerSwipe> ().SwipeDown ();
			}
		}
	}
}
