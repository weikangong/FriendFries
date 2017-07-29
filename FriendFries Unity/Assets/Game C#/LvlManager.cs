using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is in charge of changing between non-game scenes to game scenes

public class LvlManager : MonoBehaviour {

	public GameObject Score;

	public GameObject endMenu;
//	public GameObject pauseMenu;
	public GameObject popUp;

	// Use this for initialization
	void Start () {

		popUp.SetActive (false);
		//pauseMenu.SetActive (false);
		//endMenu.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ----------------------------------------------------------- //
	//UI functions

/*	public void pauseGame(){
		Debug.Log ("--- Pausing Game ---");
		pauseMenu.SetActive (true);

	}
*/

	//displays assigned pop up box
	public void showPopUp(){
		Debug.Log ("---Opening PopUp---");
		popUp.SetActive (true);

	}

	//closes assigned pop up box
	public void closePopUp(){
		Debug.Log ("---Closing PopUp---");
		popUp.SetActive (false);

	}

	public void gameOver(){
		Debug.Log ("--- Game Finished ---");
		endMenu.SetActive (true);

	}

	// ----------------------------------------------------------- //
	//Button functions

	//goes to scene for players to nter names
	public void goToEnterNames(){
		Debug.Log ("--- Going To Enter Names ---");
		Application.LoadLevel("SinglePhoneNamesScene");
	}

	//starts new game if no problems with names
	public void startNewGame(){
		
		if (!GetPlayerNames2.gotProblem) {
			Debug.Log ("--- Starting New Game ---");
			Application.LoadLevel ("SwipeTestScene");
		} else {
			Debug.Log ("--- Failed To Start New Game ---");
			showPopUp ();
		}
	}

	//overide and start game button
	public void startGameRegardless(){
		Debug.Log ("--- Starting New Game ---");
		Application.LoadLevel ("SwipeTestScene");
	}

	//sends users back to the main menu scene
	public void backtoMenu(){
		Debug.Log ("--- Back to Menu ---");
		Application.LoadLevel("SinglePhoneStartScene");
	}

	public void resetScore(){
		Score.GetComponent<ScoreSystem> ().resetScore(); //resets score back to zero
	}

	//exits the application
	public void quitGame(){
		Debug.Log ("--- Quiting Game ---");
		Application.Quit ();
	}
}
