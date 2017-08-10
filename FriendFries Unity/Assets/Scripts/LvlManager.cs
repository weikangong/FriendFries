using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is in charge of changing between non-game scenes to game scenes
public class LvlManager : MonoBehaviour { 
	public GameObject Score;
	public GameObject endMenu;
	public GameObject popUp;
    public bool pause;
    public Button pauseButton;

    public static int numPlayingPlayers;
	public static int lvlCount = 0;
	public string[] repeatableLvls = { "DragTestScene", "SqueezeTestScene" };

	void Start () {
        pause = false;
		numPlayingPlayers = GetTeamInfo.numPlayers;
        if (popUp != null) { popUp.SetActive(false); }
	}

	// ----------------------------------------------------------- //
	//UI functions
	public void pauseAndResumeGame() {
        if (GetComponent<Button>() != null) pauseButton = GetComponent<Button>();

        // Disables the pause button to prevent further popups
        if (pauseButton.interactable == true) pauseButton.interactable = false;
        else pauseButton.interactable = true;

		Debug.Log("--- Pausing/Resuming Game ---");
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
    // Goes to scene for high score
    public void goToHighScore() {
        Debug.Log("--- Going To High Score ---");
        SceneManager.LoadScene("HighScoreScene");
    }
    // Goes to scene for players to enter team info
    public void goToEnterTeamInfo() {
        Debug.Log("--- Going To Enter Team Info ---");
        SceneManager.LoadScene("EnterTeamInfoScene");
    }

    // Goes to scene for players to enter names
    public void goToEnterNames() {
		if (!GetTeamInfo.gotProblem) {
			Debug.Log ("--- Going To Enter Names ---");
            SceneManager.LoadScene("EnterNameScene");
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
            SceneManager.LoadScene("SwipeTestScene");
		} else {
			Debug.Log ("--- Failed To Start New Game ---");
			showPopUp ();
		}
	}

	// Overides and start game
	public void startGameRegardless() {
		Debug.Log ("--- Starting New Game ---");
        SceneManager.LoadScene("SwipeTestScene");
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
            SceneManager.LoadScene(picked);
		} 

		if(lvlCount > numPlayingPlayers) {
			lvlCount++;
			goLastLvl();
		}
			
	}

	public void goLastLvl() {
		Debug.Log ("--- Going to Last Level ---");
		SceneManager.LoadScene("CatchTestScene");
	}

	// Sends users back to the main menu scene
	public void backtoMenu() {
		Debug.Log ("--- Back to Menu ---");
        SceneManager.LoadScene("MenuScene");
	}

	public void endGame() {
		Debug.Log ("--- Going To End Menu ---");
        SceneManager.LoadScene("EndGameScene");
	}

    // Save team name and score and resets all info to 0
	public void reset() {
        if (Score != null) {
            HighScoreManager._instance.SaveHighScore(GetTeamInfo.teamName, ScoreSystem.currScore);
            Score.GetComponent<ScoreSystem>().resetScore(); // Resets score back to zero
        }

        GetTeamInfo.teamName = "";
        GetTeamInfo.numPlayers = 0;
        Debug.Log("Team Name reset to " + GetTeamInfo.teamName);
        Debug.Log("Number of players reset to " + GetTeamInfo.numPlayers);
        Debug.Log("Score resets to " + ScoreSystem.currScore);
    }

	// Exits the application
	public void quitGame() {
		Debug.Log("--- Quiting Game ---");
        PlayerPrefs.Save();
        Application.Quit();
	}
}
