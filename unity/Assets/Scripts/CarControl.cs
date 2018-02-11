﻿using UnityEngine;
using System.Collections;

public class CarControl : MonoBehaviour {

	public float speed;
	public string upKey;
	public string leftKey;
	public string rightKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (upKey)) {
			transform.Translate(new Vector3(-speed*Time.deltaTime,0,0));
		}
		if (Input.GetKey (leftKey)) {
			transform.Translate(new Vector3(0,-speed*Time.deltaTime,0));
		}
		if (Input.GetKey (rightKey)) {
			transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
		}

	}
}


////CarController1.js
//var wheels : Transform[];
//
//var enginePower=150.0;
//
//var power=0.0;
//var brake=0.0;
//var steer=0.0;
//
//var maxSteer=25.0;
//
//function Start(){
//	rigidbody.centerOfMass=Vector3(0,-0.5,0.3);
//}
//
//function Update () {
//	power=Input.GetAxis("Vertical") * enginePower * Time.deltaTime * 250.0;
//	steer=Input.GetAxis("Horizontal") * maxSteer;
//	brake=Input.GetKey("space") ? rigidbody.mass * 0.1: 0.0;
//	
//	GetCollider(0).steerAngle=steer;
//	GetCollider(1).steerAngle=steer;
//	
//	if(brake > 0.0){
//		GetCollider(0).brakeTorque=brake;
//		GetCollider(1).brakeTorque=brake;
//		GetCollider(2).brakeTorque=brake;
//		GetCollider(3).brakeTorque=brake;
//		GetCollider(2).motorTorque=0.0;
//		GetCollider(3).motorTorque=0.0;
//	} else {
//		GetCollider(0).brakeTorque=0;
//		GetCollider(1).brakeTorque=0;
//		GetCollider(2).brakeTorque=0;
//		GetCollider(3).brakeTorque=0;
//		GetCollider(2).motorTorque=power;
//		GetCollider(3).motorTorque=power;
//	}
//}
//
//function GetCollider(n : int) : WheelCollider{
//	return wheels[n].gameObject.GetComponent(WheelCollider);
//}
