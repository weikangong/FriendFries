using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//give this component to player objects meant to be dragged

public class PlayerDrag : MonoBehaviour {

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void Drag(Touch touch, float dragSpeed){
		// get the touch position from the screen touch to world point
		Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

		// lerp and set the position of the current object to that of the touch, but smoothly over time.
		transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * dragSpeed);

	}
		
}
