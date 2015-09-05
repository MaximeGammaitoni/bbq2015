using UnityEngine;
using System.Collections;


public class playSoundAfterTime : MonoBehaviour {
	public AudioClip adioClip;
	private float timer;
	public float playOnThisTime;
	private bool canPlay;
	// Use this for initialization
	void Start () {
		canPlay = true;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (canPlay&&timer > playOnThisTime) 
		{
			NGUITools.PlaySound(adioClip);
			canPlay=false;
		}
	}
}
