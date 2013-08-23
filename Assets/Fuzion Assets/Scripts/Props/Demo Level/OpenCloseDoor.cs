using UnityEngine;
using System.Collections;

public class OpenCloseDoor : MonoBehaviour {
	 
	private JointMotor door_motor;
	
	//Default values.  Can be set in script inspector
	public bool    is_open = false;
	public float   open_velocity = 40;
	public float   close_velocity = -40;
	
	void OnEnable()
	{
		door_motor = new JointMotor();
		door_motor.force = 10;
		if(!is_open)
		{
			door_motor.targetVelocity = open_velocity;
			is_open = true;
		}
		else if(is_open)
		{
			door_motor.targetVelocity = close_velocity;
			is_open = false;
		}

	}
	
	
	void interact()
	{
		hingeJoint.motor = door_motor;
		hingeJoint.useMotor = true;
		
		// Set the door's open/close velocity, depending on its state
	    if(!is_open)
		{
			 //print("Interact: Opening Door");
			door_motor.targetVelocity = open_velocity;
			is_open = true;										
		}
		else if(is_open)
		{
			//print("Interact: Closing Door");
			door_motor.targetVelocity = close_velocity;
			is_open = false;
		}
	}

}



