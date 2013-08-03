using UnityEngine;
using System.Collections;

public class Clock_Behaviour : MonoBehaviour {
	
	GameObject painting;
	int ignore_raycast_layer;
	
	// Use this for initialization
	void Start () {
	  ignore_raycast_layer = 2;
	  painting = GameObject.FindWithTag("Painting_Fall");
	}
	
	//Function interact() is defined for all static/dynamic objects.  Used for player interaction w/ raycasting
	void interact()
	{
		painting.SendMessage ("interact");
		
		
		//Player can no longer interact with the clock
		gameObject.layer = ignore_raycast_layer;
	}
}
