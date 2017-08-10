using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script get the number of players playing from the 
// dropdown and save that number for other scripts to use
public class GetTeamInfo : MonoBehaviour {
    public InputField getTeamName;
    public Dropdown getNumPlayers;
    public static string teamName = "";
	public static int numPlayers = 0;
	public static bool gotProblem;
    
	void Start () {
		gotProblem = true;
        getTeamName.onValueChanged.AddListener(delegate {
            LockInputTeamName(getTeamName);
        });
        getNumPlayers.onValueChanged.AddListener (delegate {
			LockInputNumPlayers(getNumPlayers);
		});
	}
	
	// Update is called once per frame
	void Update () {
		if (teamName != "" && numPlayers > 1) {
			gotProblem = false;
		} else {
			gotProblem = true;
		}
	}

    // Dropdown starts from index 0, so numPlayers is +1
    void LockInputTeamName(InputField name) {
        teamName = name.text;
        Debug.Log("Team Name: " + teamName);

    }
    // Dropdown starts from index 0, so numPlayers is +1
    void LockInputNumPlayers(Dropdown numberOfPlayers) {
		numPlayers = numberOfPlayers.value + 1;
		Debug.Log ("Number of players playing: " + numPlayers);

	}

	public int returnNumPlayers(){
		return numPlayers;
	}
}
