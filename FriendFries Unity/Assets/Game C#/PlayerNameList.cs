using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameList : MonoBehaviour {

	//public Dropdown getNumPlayers;
	//public InputField getPlayerName;

	public int numPlayers;
	public string[] playerNames;

	// Use this for initialization
	void Start () {
		//get num players from dropdown list
		//numPlayers = dropdownNumPlayers;
	
		playerNames = new string[numPlayers];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//public void 

	//public string takeInPlayerName(){
		//get name from inputfield
		//return name as string
	//}
}
