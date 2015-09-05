using UnityEngine;
using System.Collections;
using InControl;
using System;

public class InputPlayer : MonoBehaviour {
	public int playerNum;
	public GameObject camera;
	private float speed;
	// Use this for initialization
	void Start () {
		speed = 6;
	}
	
	// Update is called once per frame
	void Update () {
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;

		if (inputDevice.LeftStickY) 
		{
			gameObject.transform.Translate(new Vector3( camera.transform.forward.x ,0,camera.transform.forward.z).normalized * Time.deltaTime * inputDevice.LeftStick.Y * speed );
		}
		if (inputDevice.LeftStickX) 
		{
			gameObject.transform.Translate(new Vector3( camera.transform.right.x ,0,camera.transform.right.z).normalized * Time.deltaTime * inputDevice.LeftStick.X * speed);
		}


	}
}
