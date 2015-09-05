using UnityEngine;
using System.Collections;
using InControl;
using System;

public class InputDonjon : MonoBehaviour {
	private Quaternion saveRotate;
	public int playerNum;
	private float speed =0.25f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;

		float moveY = 0;
		float moveX = 0;
		moveX -= inputDevice.LeftStickX;
		if(moveX == 0)
			moveX -= inputDevice.DPad.X;
		moveY -= inputDevice.LeftStickY;
		if(moveY==0)
			moveY -= inputDevice.DPad.Y;
		if (inputDevice.LeftStick) 
		{
			Debug.Log ("debuSTICK");
			transform.position += new Vector3 (-moveX*speed, 0, -moveY*speed);

			if (inputDevice != null ) 
			{
				if (Mathf.Abs (inputDevice.LeftStickX) >= 0.19 || Mathf.Abs (inputDevice.LeftStickY) >= 0.19 ) {
					transform.rotation = Quaternion.Euler (new Vector3 (0, Mathf.Atan2 (inputDevice.LeftStickX, inputDevice.LeftStickY) * Mathf.Rad2Deg, 0));		
					if (transform.rotation.eulerAngles.y != 180 && transform.rotation.eulerAngles.y != -180)
						saveRotate = transform.rotation;
				}
				else 
				{
					transform.rotation = saveRotate;	
				}
			}
			else 
			{
				transform.rotation = saveRotate;	
			}
		}








	}
}
