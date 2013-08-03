using UnityEngine;
using System.Collections;

public class Painting_Fall : MonoBehaviour {
	
	bool onHook;	
	int object_interact_layer;
	int ignore_raycast_layer;
	
	// Use this for initialization
	void Start () {
	   onHook = true;
	   ignore_raycast_layer = 2;
	   gameObject.layer = ignore_raycast_layer;
	}
	
	
	//Function interact() is defined for all static/dynamic objects.  Used for player interaction w/ raycasting
	void interact()
	{
		if(onHook)
		{
			onHook = false;
			rigidbody.useGravity = true;
			
			//Now player can pickup the painting
			gameObject.layer = object_interact_layer;
		}
		
	}
	
}
