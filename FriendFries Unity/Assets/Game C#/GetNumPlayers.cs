using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNumPlayers : MonoBehaviour {

	public Dropdown getNumPlayers;
	static int numPlayers;

	// Use this for initialization
	void Start () {
		getNumPlayers.onValueChanged.AddListener (delegate {
			LockInput (getNumPlayers);
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LockInput(Dropdown numberOfPlayers) {
		numPlayers = numberOfPlayers.value + 1;
		Debug.Log ("Number of players playing: " + numPlayers);

	}

	public int returnNumPlayers(){
		return numPlayers;
	}
}
