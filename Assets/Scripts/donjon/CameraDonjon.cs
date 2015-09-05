using UnityEngine;
using System.Collections;

public class CameraDonjon : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		StartCoroutine (cameraPos ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(25, 0, 0);

	}
	IEnumerator cameraPos()
	{
		while (true) 
		{
			if(gameObject != null)
			{
				transform.rotation = Quaternion.Euler(30,0,0);
				
				transform.position =new Vector3( target.transform.position.x,target.transform.position.y+9,target.transform.position.z-12f);
				
				
				yield return 0 ;
			}
			
		}
	}
}
