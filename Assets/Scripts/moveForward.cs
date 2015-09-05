using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (new Vector3 (2 * Time.deltaTime, 0, 0));
	}
}
