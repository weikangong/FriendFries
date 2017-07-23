using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour {

	public GameObject Score;
	public GameObject Checking;

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
	//UI
/*	public void pauseGame(){
		Debug.Log ("--- Pausing Game ---");
		pauseMenu.SetActive (true);

	}
*/

	public void showPopUp(){
		Debug.Log ("---Opening PopUp---");
		popUp.SetActive (true);

	}

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
	public void goToEnterNames(){
		Debug.Log ("--- Going To Enter Names ---");
		Application.LoadLevel("SinglePhoneNamesScene");
	}

	public void startNewGame(){
		
		if (!Checking.GetComponent<GetPlayerNames> ().checkIfProblem ()) {
			Debug.Log ("--- Starting New Game ---");
			Application.LoadLevel ("SwipeTestScene");
		} else {
			Debug.Log ("--- Failed To Start New Game ---");
			showPopUp ();
		}
	}

	public void backtoMenu(){
		Debug.Log ("--- Back to Menu ---");
		Application.LoadLevel("SinglePhoneStartScene");
	}

	public void resetScore(){
		Score.GetComponent<ScoreSystem> ().resetScore(); //resets score back to zero
	}

	public void quitGame(){
		Debug.Log ("--- Quiting Game ---");
		Application.Quit ();
	}
}
