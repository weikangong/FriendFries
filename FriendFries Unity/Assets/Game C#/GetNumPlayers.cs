using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script get the number of players playing from the 
// dropdown and save that number for other scripts to use
public class GetNumPlayers : MonoBehaviour {
	public Dropdown getNumPlayers;
	public static int numPlayers = 0;
	public static bool gotProblem;
    
	void Start () {
		gotProblem = true;
		getNumPlayers.onValueChanged.AddListener (delegate {
			LockInput (getNumPlayers);
		});
	}
	
	// Update is called once per frame
	void Update () {
		if (numPlayers > 1) {
			gotProblem = false;
		} else {
			gotProblem = true;
		}
	}

	// Dropdown starts from index 0, so numPlayers is +1
	void LockInput(Dropdown numberOfPlayers) {
		numPlayers = numberOfPlayers.value + 1;
		Debug.Log ("Number of players playing: " + numPlayers);

	}

	public int returnNumPlayers(){
		return numPlayers;
	}
}
