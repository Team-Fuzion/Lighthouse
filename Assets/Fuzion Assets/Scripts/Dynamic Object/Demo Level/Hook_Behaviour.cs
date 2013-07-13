using UnityEngine;
using System.Collections;

public class Hook_Behaviour : MonoBehaviour {
	
	bool possess_painting;
	GameObject player;
	GameObject door;
	
	// Use this for initialization
	void Start () {
		//Obtain copy of objects below for interaction; Used for calling functions and sending messages
		//**gameObject player = GameObject.FindWithTag("Player");
		//**gameObject door = GameObject.FindWithTag("Painting_Door");
		possess_painting = false;
	}
	
	void interact()
	{
		//Check Player Inventory for painting
		//**possess_painting = player.GetComponent(Inventory).checkPlayerInventory(painting);
		
		if(possess_painting)
		{
			//send message to door to unlock
			//**door.SendMessage("Unlock");
		}
		
	}
	
	
	
	
}
