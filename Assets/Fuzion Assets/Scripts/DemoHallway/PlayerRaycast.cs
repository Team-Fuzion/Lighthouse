using UnityEngine;
using System.Collections;

namespace AssemblyCSharpfirstpass
{
	public class PlayerRaycast:MonoBehaviour 
	{

	
		GameObject 			cursor;
		
		RaycastHit 			  playerRay_hit;
		Vector3 			  ray_direction;
		Vector3				  ray_pos;
		
		int					  cursor_mask;
		int					  interactable_object_layer;
		
		private Interactions  demo_interact;
		
	    // Use this for initialization
	    void Awake() {
	        
			//demo_interact = new interactions
			demo_interact = GetComponent<Interactions>();
			cursor = GameObject.Find ("Cursor");
			cursor.transform.parent = Camera.main.transform;
			cursor.transform.localPosition += new Vector3(0f,0f,0.5f);
			Screen.showCursor = false;
			
			/* Bit shifts the bits of the layermask.  Since 8 is the position of the reticle layer we shift a 1 to the 
			// 8th position of the layermask.  Then we take the complement so that all bits of the layermask are set equal
			// to one and the bit for the reticle is set to 0.  Now the ray will see everything else but ignore the cursor.*/
			cursor_mask = (1<<8);
			cursor_mask = ~cursor_mask;
			interactable_object_layer = 9;
			
	    }
			
		void Update()
		{
						
				//Player Controls for Selecting Objects.  Should be run under a fixedUpdate()
			    ray_pos = Camera.main.transform.position;
			    ray_direction = Camera.main.transform.forward;//(cursor.transform.position - Camera.main.transform.position);
				Physics.Raycast(ray_pos, ray_direction, out playerRay_hit,5f,cursor_mask);
		
		   		//Player Controls for Selecting Objects
				if(Input.GetMouseButtonDown(0))
				{
			  		//if(playerRay_hit != null)
			  		//{
			   			if(playerRay_hit.collider != null)
			   			{
			    			if(playerRay_hit.collider.gameObject.layer == interactable_object_layer)
			     			{
			     				playerRay_hit.collider.gameObject.SendMessage("interact");
				    			print(playerRay_hit.collider.gameObject.name);
							}
			   			}
			  		//}  
				}
			demo_interact.interact(ray_direction, ray_pos);
		}//update
 }
}

