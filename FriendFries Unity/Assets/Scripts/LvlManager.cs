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
    // Pause or resume the game, depending on the current state
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
    // Goes to scene for players to enter team info
    public void goToEnterTeamInfo() {
        Debug.Log("--- Going To Enter Team Info ---");
        SceneManager.LoadScene("EnterTeamInfoScene");
    }

    // Goes to scene for players to enter names
    public void goToEnterPlayerNames() {
		if (!GetTeamInfo.gotProblem) {
			Debug.Log ("--- Going To Enter Names ---");
            SceneManager.LoadScene("EnterPlayerNamesScene");
		} else {
            Debug.Log("Failed to enter number of players");
            showPopUp();
        }
	}

	// Starts new game if no problems with names
	public void startNewGame() {
		if (!GetPlayerNames2.gotProblem) {
			Debug.Log ("--- Starting New Game ---");
			lvlCount+=2;
            SceneManager.LoadScene("SwipeTestScene");
		} else {
			Debug.Log ("--- Failed To Start New Game ---");
			showPopUp ();
		}
	}

	// Picks a level that can be repeatable
	public string pickLvl() {
		string picked = repeatableLvls [(int) Random.Range (0, repeatableLvls.Length)];
		Debug.Log ("Picked Lvl: " + picked);
		return picked;
	}

	// Goes to level picked
	public void goNextLvl() {
        if (lvlCount < numPlayingPlayers) {
			lvlCount++;
            Debug.Log("lvlCount: " + lvlCount);
            SceneManager.LoadScene(pickLvl());
		} else {
            goLastLvl(); }
			
	}

    // Goes to scene for catching the fries
	public void goLastLvl() {
		Debug.Log ("--- Going to Last Level ---");
		SceneManager.LoadScene("CatchTestScene");
	}

    // Goes to scene for end of game
    public void endGame() {
        Debug.Log("--- Going To End Menu ---");
        SceneManager.LoadScene("EndGameScene");
    }

    // Goes to scene for menu
    public void backtoMenu() {
		Debug.Log ("--- Back to Menu ---");
        SceneManager.LoadScene("MenuScene");
	}

    // Goes to scene for high score
    public void goToHighScore() {
        Debug.Log("--- Going To High Score ---");
        SceneManager.LoadScene("HighScoreScene");
    }

    // Save team name and score for high score
    public void saveHighScore() {
        HighScoreManager._instance.SaveHighScore(GetTeamInfo.teamName, ScoreSystem.currScore);
    }

    public void clearHighScore() {
        HighScoreManager._instance.ClearHighScore();
    }

    // Resets all player info to 0
	public void resetAll() {
        GetTeamInfo.teamName = "";
        GetTeamInfo.numPlayers = 0;
        ScoreSystem.currScore = 0;
        lvlCount = 0;

        Debug.Log("Team Name reset to \"" + GetTeamInfo.teamName +"\"");
        Debug.Log("Number of players reset to " + GetTeamInfo.numPlayers);
        Debug.Log("Score resets to " + ScoreSystem.currScore);
        Debug.Log("lvlCount resets to " + lvlCount);
    }

	// Exits the application
	public void quitGame() {
		Debug.Log("--- Quiting Game ---");
        PlayerPrefs.Save();
        Application.Quit();
	}
}
