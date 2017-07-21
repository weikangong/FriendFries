using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour {

	public GameObject endMenu;
//	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		
		//pauseMenu.SetActive (false);
		//endMenu.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ----------------------------------------------------------- //
	//Menu UI
/*	public void pauseGame(){
		Debug.Log ("--- Pausing Game ---");
		pauseMenu.SetActive (true);

	}
*/
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
		Debug.Log ("--- Starting New Game ---");
		Application.LoadLevel("SwipeTestScene");
	}

	public void backtoMenu(){
		Debug.Log ("--- Back to Menu ---");
		Application.LoadLevel("SinglePhoneStartScene");
	}

	public void quitGame(){
		Debug.Log ("--- Quiting Game ---");
		Application.Quit ();
	}
}
