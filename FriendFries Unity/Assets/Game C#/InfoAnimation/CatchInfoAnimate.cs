using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchInfoAnimate : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		StartCoroutine(PlayAnimInterval(2, 3.0F));
	}

	// Update is called once per frame
	void Update () {

	}

	private IEnumerator PlayAnimInterval(int n, float time) {
		while (n > 0) {
			anim.Play ("CatchInfo", 0, 0F);
			--n;
			yield return new WaitForSeconds (time);
		}

		if (n <= 0) {
			Destroy (this.gameObject);
		}
	}
}
