using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWallTrigger : MonoBehaviour {

	bool touchedExitWall = false;
	public string nextLevel;
	public float waitTime;
	public int fontSize;

	public string nextPlayerMessage;

	void OnTriggerEnter2D(Collider2D other) {
		touchedExitWall = true;
		Debug.Log ("Collision with exit wall detected: " + other.gameObject.name);

		if (other.gameObject.tag == "Potato") {
			Destroy (other.gameObject);
		}

		//changes scene
		StartCoroutine("Wait");

	}

	IEnumerator Wait() {
		yield return new WaitForSecondsRealtime (waitTime);
		Application.LoadLevel (nextLevel);
	}

	void OnGUI() {

		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = fontSize;

		if (touchedExitWall) {
			GUI.Label (new Rect (Screen.width/2, Screen.height/2, 200, 100), nextPlayerMessage, centeredStyle);
		}
	}
}
