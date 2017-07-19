using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class PinchFunction : MonoBehaviour {

	float pinchDistance;
	float pinchDistanceDelta;

	const float pinchRatio = 1;
	const float minPinchDistance = 0;

	bool pinched = false; 

	public float totalKetchup = 100;
	public float ketchupLeft;
	bool noMoreKetchup = false;

	private SpriteRenderer myRenderer;
	public Sprite[] bottle;

	public ParticleSystem ketchupEmit;

	// Use this for initialization
	void Start () {
		ketchupLeft = totalKetchup;
		myRenderer = gameObject.GetComponent<SpriteRenderer> ();
		ketchupEmit = gameObject.GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {

		// if two fingers are touching the screen at the same time
		if (Input.touchCount == 2) {
			Touch touch1 = Input.touches [0];
			Touch touch2 = Input.touches [1];

			//if at least one of them moved
			if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) {
				//check the delta distance between them
				pinchDistance = Vector2.Distance (touch1.position, touch2.position);
				float prevDistance = Vector2.Distance (touch1.position - touch1.deltaPosition,
					                     touch2.position - touch2.deltaPosition);
				pinchDistanceDelta = pinchDistance - prevDistance;

				//if it's greater than a minimum threshold, it's a pinch!
				//and fingers must be going towards each other
				if (-pinchDistanceDelta > minPinchDistance) {
					pinchDistanceDelta *= pinchRatio;
					pinched = true;
					Debug.Log ("Pinched Detected");

				} else {
					pinchDistance = pinchDistanceDelta = 0;
				}
			}

			//decrease ketchup when pinched
			if (pinched) {
				ketchupLeft--;

				//still has ketchup
				if (ketchupLeft > 0) {
					noMoreKetchup = false;
				}

				//no more ketchup
				if (ketchupLeft <= 0) {
					
					noMoreKetchup = true;
					Debug.Log ("No more ketchup");
				}
			}

			//stopped pinching
			if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended) {
				pinched = false;
				Debug.Log ("Pinched Stopped");
			}
		}

		//------------------------------------------------------------------------------------//

		//particle system, only emits when pinched and has ketchup
		if (pinched && !noMoreKetchup) {
			ketchupEmit.Emit (1);
		}
		if (!pinched || noMoreKetchup) {
			ketchupEmit.Stop ();
		}

		//shows sprite respective to amt of ketchup left
		if (ketchupLeft <= totalKetchup && ketchupLeft > totalKetchup/4*3){
			myRenderer.sprite = bottle[0];
		}

		if (ketchupLeft <= totalKetchup/4*3 && ketchupLeft > totalKetchup/4*2){
			myRenderer.sprite = bottle[1];
		}

		if (ketchupLeft <= totalKetchup/4*2 && ketchupLeft > totalKetchup/4*1){
			myRenderer.sprite = bottle[2];
		}

		if (ketchupLeft <= 0){
			myRenderer.sprite = bottle[3];
		}

	}

	void OnGUI() {

		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = 45;

	}
}
