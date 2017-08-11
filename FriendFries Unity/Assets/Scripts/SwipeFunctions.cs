using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Swiping any object with tag "potato" will cause object to move in direction.
// No diagonal directions. will move only if object is touched.
public class SwipeFunctions : MonoBehaviour {

	public GameObject Player;
	public GameObject SpawnFry;

	public float maxTime; // Max time of which exceeding is not counted as a swipe
	public float minSwipeDist; // Min swipe distance of which not reaching is not counted as a swipe

	float startTime; // Time when finger first touches screen
	float endTime; // Time when finger is lifted off screen

	Vector3 startPos; // Starting position on screen (touched screen)
	Vector3 endPos; // Ending position on screen (lift finger)

	float swipeDist; // Swipe distance between two points
	float swipeTime;
	float swipeVelocity;

	bool potatoTouched = false;

    // ---------------------------------------------------------------------------------------------- //
    // Time it takes to spawn the Goodies
    [Space(3)]
    public float waitingForNextSpawn;
    public float theCountdown;
    public int friesLeft;

	// The range of X
	[Header ("X Spawn Range")]
	public float xMin;
	public float xMax;

	// The range of y
	[Header ("Y Spawn Range")]
	public float yMin;
	public float yMax;


	// ---------------------------------------------------------------------------------------------- //
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				startTime = Time.time;
				startPos = touch.position;

				// Check if object is touched
				Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				if(Physics2D.Raycast(test, (Input.GetTouch(0).position)).collider.tag == "Potato") {
					potatoTouched = true;
					Debug.Log("Potato touched");
				}
			} 

			else if (touch.phase == TouchPhase.Ended) {
				endTime = Time.time;
				endPos = touch.position;

				// Checking for swipe
				swipeDist = (endPos - startPos).magnitude;
				swipeTime = endTime - startTime;

				if ((swipeTime < maxTime) && (swipeDist > minSwipeDist) && potatoTouched) {
					swipe ();
					potatoTouched = false;
				}
			}
		}

		// --------------------------------------------------------------------------------------- //
		// Timer to spawn the next goodie Object
		theCountdown -= Time.deltaTime;
		if(theCountdown <= 0 && friesLeft > 0) {
            spawnFries ();
			theCountdown = waitingForNextSpawn;
			friesLeft--;
		}
		if (theCountdown <= 0 && friesLeft <= 0) {
			//Debug.Log ("No more fries");
		}

		// ---------------------------------------------------------------------------------------- //
	}

	void swipe() { 
		Vector2 distance = endPos - startPos;
		swipeVelocity = swipeDist / swipeTime; //used for multiplierForceA

		Player.GetComponent<PlayerSwipe> ().Swipe (distance.x, distance.y, swipeVelocity);
	}

	public void spawnFries() {
		// Defines the min and max ranges for x and y
		Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
		Quaternion rot = transform.localRotation;
		rot = Quaternion.AngleAxis(Random.Range(-45, 45), transform.forward) * transform.rotation;


		// Creates the random object at the random 2D position
		Debug.Log ("Spawning Fry: " + friesLeft);
		GameObject fryClone = (GameObject)Instantiate (SpawnFry, pos, rot);
		Player = fryClone;
	}
}
