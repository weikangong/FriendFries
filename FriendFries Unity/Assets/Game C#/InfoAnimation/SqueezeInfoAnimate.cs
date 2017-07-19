using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueezeInfoAnimate : MonoBehaviour {

	public Animator animL;
	public Animator animR;

	// Use this for initialization
	void Start () {
		animL = GetComponentInChildren<Animator> ();
		animR = GetComponentInChildren<Animator> ();
		StartCoroutine(PlayAnimInterval(5, 1F));
	}

	// Update is called once per frame
	void Update () {

	}

	private IEnumerator PlayAnimInterval(int n, float time) {
		while (n > 0) {
			animL.Play ("SqueezeLInfo", 0, 0F);
			animR.Play ("SqueezeRInfo", 0, 0F);
			--n;
			yield return new WaitForSeconds (time);
		}

		if (n <= 0) {
			Destroy (this.gameObject);
		}
	}
}
