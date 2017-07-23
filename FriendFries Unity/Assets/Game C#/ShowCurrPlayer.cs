using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowCurrPlayer : MonoBehaviour {

	public Text currPlayerText;

	public GameObject PlayerNameList;
	static string[] playingPlayerNames;
	public GameObject PlayerNumbers;
	int numPlayingPlayers;

	static string currPlayer;

	// Use this for initialization
	void Start () {
		numPlayingPlayers = PlayerNumbers.GetComponent<GetNumPlayers> ().returnNumPlayers ();
		playingPlayerNames = new string[numPlayingPlayers];
		playingPlayerNames = PlayerNameList.GetComponent<GetPlayerNames> ().returnPlayingPlayerNames ();

		currPlayer = pickRandomPlayer (playingPlayerNames);
		setNameText ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	string pickRandomPlayer(string[] nameList){
		string pickedPlayer = nameList[Random.Range(0, nameList.Length)];
		return pickedPlayer;
	}
	void setNameText(){
		currPlayerText.text = currPlayer.ToString ();
	}
}
