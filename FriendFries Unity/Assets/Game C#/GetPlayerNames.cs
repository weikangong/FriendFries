using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerNames : MonoBehaviour {

	public InputField[] getPlayerName;
	string[] playerNames;

	public GameObject PlayerNumbers;
	int numPlayingPlayers;

	public bool missingName;

	public void Start()
	{
		numPlayingPlayers = PlayerNumbers.GetComponent<GetNumPlayers> ().returnNumPlayers ();
		playerNames = new string[10];
		//Adds a listener that invokes the "LockInput" method when the player finishes editing the main input field.
		//Passes the main input field into the method when "LockInput" is invoked

		getPlayerName [0].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [0], 0);
		});

		getPlayerName [1].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [1], 1);
		});
			
		getPlayerName [2].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [2], 2);
		});

		getPlayerName [3].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [3], 3);
		});

		getPlayerName [4].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [4], 4);
		});

		getPlayerName [5].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [5], 5);
		});

		getPlayerName [6].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [6], 6);
		});

		getPlayerName [7].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [7], 7);
		});

		getPlayerName [8].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [8], 8);
		});

		getPlayerName [9].onEndEdit.AddListener (delegate {
			LockInput (getPlayerName [9], 9);
		});

	}

	// Checks if there is anything entered into the input field.
	void LockInput(InputField input, int arrayPlayerNo) {
		int actualPlayerNo = arrayPlayerNo + 1;

		if (input.text.Length > 0) {
			Debug.Log(input.text + " has been entered");
			playerNames [arrayPlayerNo] = input.text; //assigns inputfield names to playerNames string array
			Debug.Log ("Player " + actualPlayerNo + "'s name is: " + playerNames [arrayPlayerNo]);

		} else if (input.text.Length == 0) {
			Debug.Log("Input Empty");
			playerNames [arrayPlayerNo] = null; //assigns null to empty input fields

		}
	}

	void Update() {
		missingName = checkPlayers ();
	}

	bool checkPlayers(){
		for (int i = 0; i < numPlayingPlayers; i++) {
			if (playerNames [i] == null) {
				return true;
			} 
		}

		return false;
	}

	public bool checkIfMissingName(){
		return missingName;
	}

	public string[] returnPlayerNames(){
		return playerNames;
	}

}
