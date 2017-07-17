using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Swiping any object with tag "potato" will cause object to move in direction.
//No diagonal directions. will move only if object is touched.

public class SwipeFunctions : MonoBehaviour {

	public GameObject Player;
	public GameObject SpawnFry;

	public float maxTime; //max time of which exceeding is not counted as a swipe
	public float minSwipeDist; //min swipe distance of which not reaching is not counted as a swipe

	float startTime; //time when finger first touches screen
	float endTime; //time when finger is lifted off screen

	Vector3 startPos; //starting position on screen (touched screen)
	Vector3 endPos; //ending position on screen (lift finger)

	float swipeDist; //swipe distance btw two points
	float swipeTime;

	bool potatoTouched = false;

	// ---------------------------------------------------------------------------------------------- //

	//Time it takes to spawn theGoodies
	[Space(3)]
	public float waitingForNextSpawn = 10;
	public float theCountdown = 10;
	public float friesLeft = 5;

	// the range of X
	[Header ("X Spawn Range")]
	public float xMin;
	public float xMax;

	// the range of y
	[Header ("Y Spawn Range")]
	public float yMin;
	public float yMax;


	// ---------------------------------------------------------------------------------------------- //

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

				//check if object is touched
				Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				if(Physics2D.Raycast(test, (Input.GetTouch(0).position)).collider.tag == "Potato") {
					potatoTouched = true;
					Debug.Log("Potato touched");
				}
			} 

			else if (touch.phase == TouchPhase.Ended) {
				endTime = Time.time;
				endPos = touch.position;

				//checking for swipe
				swipeDist = (endPos - startPos).magnitude;
				swipeTime = endTime - startTime;

				if ((swipeTime < maxTime) && (swipeDist > minSwipeDist) && potatoTouched) {
					swipe ();
					potatoTouched = false;
				}
			}
		}

		// --------------------------------------------------------------------------------------- //

		// timer to spawn the next goodie Object
		theCountdown -= Time.deltaTime;
		if(theCountdown <= 0 && friesLeft > 0)
		{
			spawnFries ();
			theCountdown = waitingForNextSpawn;
			friesLeft--;
		}
		if (theCountdown <= 0 && friesLeft <= 0) {
			Debug.Log ("No more fries");
		}

		// ---------------------------------------------------------------------------------------- //
	}

	void swipe() {
		
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

	public void spawnFries() {
		// Defines the min and max ranges for x and y
		Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
		Quaternion rot = transform.localRotation;
		rot = Quaternion.AngleAxis(Random.Range(-45, 45), transform.forward) * transform.rotation;


		// Creates the random object at the random 2D position.
		Debug.Log ("Spawning Fry: " + friesLeft);
		GameObject fryClone = (GameObject)Instantiate (SpawnFry, pos, rot);
		Player = fryClone;
	}
}
