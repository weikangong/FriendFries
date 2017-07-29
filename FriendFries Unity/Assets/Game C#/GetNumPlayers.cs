using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script get the number of players playing from the dropdown and save that number for other scripts use

public class GetNumPlayers : MonoBehaviour {

	public Dropdown getNumPlayers;
	public static int numPlayers;

	// Use this for initialization
	void Start () {
		getNumPlayers.onValueChanged.AddListener (delegate {
			LockInput (getNumPlayers);
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//dropdown starts from index 0, so numPlayers is +1
	void LockInput(Dropdown numberOfPlayers) {
		numPlayers = numberOfPlayers.value + 1;
		Debug.Log ("Number of players playing: " + numPlayers);

	}

	public int returnNumPlayers(){
		return numPlayers;
	}
}
