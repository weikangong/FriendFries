using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

	//Array of objects to spawn (note I've removed the private goods variable)
	public GameObject fries;


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


	void Start() {
		
	}

	public void Update() {
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
	}


	void spawnFries() {
		// Defines the min and max ranges for x and y
		Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
		Quaternion rot = transform.localRotation;
		rot = Quaternion.AngleAxis(Random.Range(0, 360), transform.forward) * transform.rotation;


		// Creates the random object at the random 2D position.
		Debug.Log ("Spawning Fry, Fries left: " + friesLeft);
		Instantiate (fries, pos, rot);
	
	}
}