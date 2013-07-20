
using UnityEngine;
using System.Collections;
 
// Require a character controller to be attached to the same game object
[RequireComponent (typeof (CharacterMotorC))]
 
//RequireComponent (CharacterMotor)
[AddComponentMenu("Character/FPS Input Controller C")]
//@script AddComponentMenu ("Character/FPS Input Controller")
 
 
public class FPSInputControllerC : MonoBehaviour {
    private CharacterMotorC cmotor;
	
	GameObject 			cursor;
	
	RaycastHit 			playerRay_hit;
	Vector3 			ray_direction;
	Vector3				ray_pos;
	
	int					cursor_mask;
	int					interactable_object_layer;
	
    // Use this for initialization
    void Awake() {
        cmotor = GetComponent<CharacterMotorC>();
		
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
 
    // Update is called once per frame
    void Update () {
        // Get the input vector from keyboard or analog stick
        Vector3 directionVector;
        directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (directionVector != Vector3.zero) {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;
 
            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);
 
            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;
 
            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;
        }
 
        // Apply the direction to the CharacterMotor
        cmotor.inputMoveDirection = transform.rotation * directionVector;
        cmotor.inputJump = Input.GetButton("Jump");
		
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
    }//update
 
}