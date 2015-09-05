using UnityEngine;
using InControl;


public class ButtonManager : MonoBehaviour
{
	private float timer;
	public bool playTimer;
	public Button focusedButton;
	public GameObject forTweening;
	private bool canMove;
		
	void Awake()
	{
		canMove = true;
		playTimer = false;
		TwoAxisInputControl.StateThreshold = 0.7f;
	}
		
		
	void Update()
	{
			// Use last device which provided input.
		var inputDevice = InputManager.ActiveDevice;
			
			// Move focus with directional inputs.
		if (inputDevice.Direction.Up.WasPressed  && canMove) 
		{
			MoveFocusTo( focusedButton.up );
		}

			
		if (inputDevice.Direction.Down.WasPressed && canMove) 
		{
			MoveFocusTo( focusedButton.down );
		} 
		if (inputDevice.Direction.Left.WasPressed&& canMove) 
		{	
			MoveFocusTo( focusedButton.left );
		} 
		if (inputDevice.Direction.Right.WasPressed && canMove) 
		{
			MoveFocusTo( focusedButton.right );
		}
		if (inputDevice.Action1.WasPressed && canMove) 
		{	
			playTimer = true;
			canMove=false;
			TweenAlpha.Begin(forTweening,0.5f,1);

		}
		if (playTimer)
			timer += Time.deltaTime;

		if (timer >= 0.9) 
		{

			if(focusedButton.GetComponent<Button>().levelToLoad=="quit")
			{
				Debug.Log ("QUIT");
				Application.CancelQuit();
				Application.Quit();
			}
				
			else
			Application.LoadLevel(focusedButton.GetComponent<Button>().levelToLoad);
		}
			

			
	}
		
		
		void MoveFocusTo( Button newFocusedButton )
		{
			if (newFocusedButton != null)
			{
				focusedButton = newFocusedButton;
				Debug.Log (focusedButton.tag);
			}
		}
	}
