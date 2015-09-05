using UnityEngine;
using System.Collections;
using System;
using InControl;

public class InputBomberman : MonoBehaviour {
	private int playerNum = 0 ;
	private int speed = 5;
	private bool canMove;
	// Use this for initialization
	void Start () {
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;

		if (inputDevice.DPadDown) 
		{
			if(canMove){
				gameObject.transform.rotation = (Quaternion.Euler( 0,180,0));
				StartCoroutine(translate (-transform.forward,inputDevice));
			}

		}
		else if (inputDevice.DPadUp) 
		{
			if(canMove){
				gameObject.transform.rotation = (Quaternion.Euler( 0,0,0));
				StartCoroutine(translate (transform.forward,inputDevice));
			}
		}
		else if (inputDevice.DPadRight) 
		{
			if(canMove){
				gameObject.transform.rotation = (Quaternion.Euler( 0,90,0));
				StartCoroutine(translate (-transform.right,inputDevice));
			}
		}
		else if (inputDevice.DPadLeft) 
		{
			if(canMove){

				gameObject.transform.rotation = (Quaternion.Euler( 0,270,0));
				StartCoroutine(translate (transform.right, inputDevice));
			}
		}
	}

	IEnumerator translate(Vector3 dir, InputDevice input)
	{
		float timer=0;
		while (timer <= 0.1) 
		{
			canMove = false;
			timer += Time.deltaTime;
			gameObject.transform.Translate(dir * (Time.deltaTime / 0.1f));
			yield return new WaitForSeconds(Time.deltaTime);
			Debug.Log ("OKAAAAY");
		}
		if(!input.DPad)
		transform.position = new Vector3 (Mathf.Round (transform.position.x), transform.position.y, Mathf.Round (transform.position.z));

		canMove = true;
		yield return 0;
	} 
}
