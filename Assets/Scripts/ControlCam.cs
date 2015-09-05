using UnityEngine;
using System.Collections;
using System;
using InControl;

public class ControlCam : MonoBehaviour {
	public bool canMoveCamera;
	public int playerNum;
	public float minDist;
	public float maxDist;
	public float minElevation;
	public float maxElevation;
	public float elevation;
	public float azimutSpeed;
	public float distanceSpeed;
	public float elevationSpeed;
	public Transform target;
	public float startAzimut = 45f;
	float azimut;
	float distance;
	public float kLerpPos;
	
	Vector3 targetPos;


	
	// Use this for initialization
	void Start () {
		canMoveCamera = true;
		distance = (minDist+maxDist)/2f;
		azimut = startAzimut;
		elevation*=Mathf.PI/180f;
		minElevation*=Mathf.PI/180f;
		maxElevation*=Mathf.PI/180f;
	}
	
	// Update is called once per frame
	void Update () {

		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;



		if(Input.GetKey(KeyCode.Q)||( Input.GetMouseButton (1) && Input.GetAxis("Mouse X") < 0 ) || inputDevice.RightStickX < 0 && canMoveCamera   )

			azimut-=azimutSpeed*Time.deltaTime * -inputDevice.RightStickX;
		else if(Input.GetKey(KeyCode.D)||( Input.GetMouseButton (1)&& Input.GetAxis("Mouse X") > 0 ) || inputDevice.RightStickX > 0 && canMoveCamera )

			azimut+=azimutSpeed*Time.deltaTime*inputDevice.RightStickX;
			
			
		if(Input.GetKey(KeyCode.Z)||( Input.GetMouseButton (1)&& Input.GetAxis("Mouse Y") >0 )||inputDevice.RightStickY > 0 && canMoveCamera)

			elevation+=elevationSpeed*Time.deltaTime*inputDevice.RightStickY;
		else if(Input.GetKey(KeyCode.S)||( Input.GetMouseButton (1)&& Input.GetAxis("Mouse Y") <0 )||inputDevice.RightStickX < 0&& canMoveCamera)

			elevation-=elevationSpeed*Time.deltaTime*-inputDevice.RightStickY;
			elevation = Mathf.Clamp(elevation,minElevation,maxElevation);
			
		if (inputDevice.RightBumper) {
			canMoveCamera = false;
			distance = Mathf.Clamp (
			distance - distanceSpeed * inputDevice.RightStickY * 0.2f * Time.deltaTime, minDist, maxDist);
			} 
		else
			canMoveCamera = true;
			
			
			Vector3 dirH = new Vector3(Mathf.Cos(azimut),0,Mathf.Sin(azimut));
			
			Vector3 newPos = target.position+dirH*distance*Mathf.Cos(elevation)+Vector3.up*distance*Mathf.Sin(elevation);
			transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * kLerpPos); //j'aplique le mouvement smooth au clavier
			if (Input.GetMouseButton (1)) 
			{
			transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime *3); //j'aplique le mouvement smooth au clavier
			}
			transform.LookAt (target);

		//setAngle(); A VERIFIER POUR LA GUI

	}

	/*void setAngle () {
		lattAngle = lattitude / Mathf.PI * 180 + 90;
	}*/ //A VERIFIER POUR LA GUI
	

	
	

}
