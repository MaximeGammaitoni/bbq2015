using UnityEngine;
using System.Collections;

public class bridge : MonoBehaviour {
	public float maxElevation;
	public float minElevation;
	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goCorouts()
	{
		StartCoroutine (rotate ());
	}
	public void goCorouts2()
	{
		StartCoroutine (rotate2 ());
	}
	public void goElevation()
	{
		StartCoroutine (elevation ());
	}
	public void goDown()
	{
		StartCoroutine (down ());
	}
	IEnumerator rotate()
	{
		while (transform.rotation.eulerAngles.y <= 180) 
		{
			transform.Rotate(new Vector3(0,2f,0));
			yield return 0 ;
		}
		transform.rotation = Quaternion.Euler (0, 0, 0);
		yield return 0;
	}
	IEnumerator rotate2()
	{
		while (transform.rotation.eulerAngles.y <= 90) 
		{
			transform.Rotate(new Vector3(0,2f,0));
			yield return 0 ;
		}
		transform.rotation = Quaternion.Euler (0, 90, 0);
		yield return 0;
	}
	IEnumerator elevation()
	{
		while (transform.position.y <= maxElevation) 
		{
			transform.position +=new Vector3(0,speed,0);
			yield return 0 ;
		}

		yield return 0;
	}
	IEnumerator down()
	{
		while (transform.position.y >= minElevation) 
		{
			transform.position +=new Vector3(0,-speed,0);
			yield return 0 ;
		}
		
		yield return 0;
	}
}
