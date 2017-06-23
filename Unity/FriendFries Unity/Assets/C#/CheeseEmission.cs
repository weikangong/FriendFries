using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseEmission : MonoBehaviour {

	//ParticleSystem ps;
	Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	//	ps = GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		//particles should ony emit when object is moving
		if(rb.velocity.magnitude > 0){
//			ps.Play;
		}

	}
}
