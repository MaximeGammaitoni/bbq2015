using UnityEngine;
using System.Collections;

public class interupt : MonoBehaviour {
	public GameObject target;
	public string action;
	private bool canActivate;
	private float timer=0;
	// Use this for initialization
	void Start () {
		canActivate = true;
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		if (timer >= 2) 
		{
			if (canActivate && Physics.Raycast (transform.position, new Vector3 (0, 0.01f, 0), out hit, 1)) 
			{
				timer = 0;
				canActivate = false;
				if(action == "rotate")
					target.GetComponent<bridge>().goCorouts();
				if(action== "elevation")
					target.GetComponent<bridge>().goElevation();
			}
			else if(!canActivate && !Physics.Raycast (transform.position, new Vector3 (0, 0.01f, 0), out hit, 1))
			{
				timer =0 ;
				canActivate = true;
				if(action == "rotate")
					target.GetComponent<bridge>().goCorouts2();
				if(action== "elevation")
					target.GetComponent<bridge>().goDown();
			}
		}
		else 
		{

			timer +=Time.deltaTime;
		}





	}
}
