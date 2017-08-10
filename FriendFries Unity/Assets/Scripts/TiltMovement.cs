using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Give the Rigid Body called in the script the ability to move based on
//accelerometer input from the phone
public class TiltMovement : MonoBehaviour {

    Rigidbody2D rb;             //Rigid Body Definition
    public float Sensitivity;   //Sensitivity for the tilt controls (Between 1-100)
    public float Speed;         //Speed of the Catcher movement (Non-zero Values) 

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

       
        float AcceleratorX = 0;

        //Debugger line for detecting Accelerometer input
        if(Input.acceleration.x != 0) {
            if(Input.acceleration.x > 0) {
                //Debug.Log("Right tilt detected");
            } else {
               // Debug.Log("Left tilt detected");
            }
        } else{
           // Debug.Log("No tilt detected");
        }

        //Adjusts the acceleration value with respect to sensitivity
        AcceleratorX = Input.acceleration.x * (Sensitivity / 100);

        //Creates the vector definition for the force input
        Vector3 Movement = new Vector3(AcceleratorX, 0, 0);

        //Inputs the defined force onto the Rigid body
        rb.AddForce(Movement * Speed);
        
    }
}
