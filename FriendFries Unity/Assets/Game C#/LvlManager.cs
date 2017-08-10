using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is in charge of changing between non-game scenes to game scenes
public class LvlManager : MonoBehaviour {

	public GameObject Score;
	public GameObject endMenu;
	public GameObject popUp;
    public bool pause;

	public static int numPlayingPlayers;
	public static int lvlCount = 0;
	public string[] repeatableLvls = { "DragTestScene", "SqueezeTestScene" };

	void Start () {
        pause = false;
		numPlayingPlayers = GetNumPlayers.numPlayers;
        if (popUp != null) { popUp.SetActive(false); }
	}

	// ----------------------------------------------------------- //
	//UI functions
	public void pauseAndResumeGame() {
		Debug.Log ("--- Pausing/Resuming Game ---");
        pause = !pause;
        if (!pause) Time.timeScale = 1;
        else Time.timeScale = 0;
		
	}

	// Displays assigned popup box
	public void showPopUp() {
		Debug.Log ("---Opening PopUp---");
		popUp.SetActive(true);

	}

	// Closes assigned pop up box
	public void closePopUp() {
		Debug.Log ("---Closing PopUp---");
		popUp.SetActive(false);

	}

	public void gameOver() {
		Debug.Log ("--- Game Finished ---");
		endMenu.SetActive (true);

	}

	// Button functions
	// Goes to scene for players to enter names
	public void goToEnterNames() {
		if (!GetNumPlayers.gotProblem) {
			Debug.Log ("--- Going To Enter Names ---");
			Application.LoadLevel ("EnterNameScene");
		} else {
            Debug.Log("Failed to enter number of players");
            showPopUp();
        }
	}

	// Starts new game if no problems with names
	public void startNewGame() {
		if (!GetPlayerNames2.gotProblem) {
			Debug.Log ("--- Starting New Game ---");
			lvlCount++;
			Application.LoadLevel ("SwipeTestScene");
		} else {
			Debug.Log ("--- Failed To Start New Game ---");
			showPopUp ();
		}
	}

	// Overides and start game
	public void startGameRegardless() {
		Debug.Log ("--- Starting New Game ---");
		Application.LoadLevel ("SwipeTestScene");
	}

	// Picks a level that can be repeatable
	public string pickLvl() {
		string picked = repeatableLvls [(int) Random.Range (0, repeatableLvls.Length)];
		Debug.Log ("Picked Lvl: " + picked);
		return picked;
	}

	// Goes to level picked
	public void goNextLvl() {
		string picked = pickLvl ();

		if (numPlayingPlayers == 1) {
			endGame ();
		}

		if (lvlCount <= numPlayingPlayers) {
			lvlCount++;
			Debug.Log ("Lvl Count: " + lvlCount);
			Application.LoadLevel (picked);
		} 

		if(lvlCount > numPlayingPlayers) {
			lvlCount++;
			goLastLvl ();
		}
			
	}

	public void goLastLvl() {
		Debug.Log ("--- Going to Last Level ---");
		Application.LoadLevel("CatchTestScene");
	}

	// Sends users back to the main menu scene
	public void backtoMenu() {
		Debug.Log ("--- Back to Menu ---");
		Application.LoadLevel("MenuScene");
	}

	public void endGame() {
		Debug.Log ("--- Going To End Menu ---");
		Application.LoadLevel("EndGameScene");
	}

    // Resets score and number of players to 0
	public void reset() {
        if (Score != null) {
            Score.GetComponent<ScoreSystem>().resetScore(); // Resets score back to zero
        }
        GetNumPlayers.numPlayers = 0;
        Debug.Log("Number of players reset to 0");
    }

	// Exits the application
	public void quitGame() {
		Debug.Log("--- Quiting Game ---");
		Application.Quit();
	}
}
