private var motor : CharacterMotor;

var cursor : GameObject;
var playerRay_hit : RaycastHit;
var ray_direction: Vector3;

var cursor_mask : int;

// Use this for initialization.
function Awake () {
	motor = GetComponent(CharacterMotor);
	
	cursor = GameObject.Find("Cursor");
	cursor.transform.parent = Camera.main.transform;
	cursor.transform.localPosition = Vector3(0,0,0.5);
	Screen.showCursor = false;
	
	/* Bit shifts the bits of the layermask.  Since 8 is the position of the reticle layer we shift a 1 to the 
	// 8th position of the layermask.  Then we take the complement so that all bits of the layermask are set equal
	// to one and the bit for the reticle is set to 0.  Now the ray will see everything else but ignore the cursor.*/
	cursor_mask = (1<<8);
	cursor_mask = ~cursor_mask;
	
}

// Update is called once per frame
function Update () {
	// Get the input vector from kayboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
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
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetButton("Jump");
	
	
	//Player Controls for Selecting Objects.  Should be run under a fixedUpdate()
	    ray_pos = Camera.main.transform.position;
	    ray_direction = Camera.main.transform.forward;//(cursor.transform.position - Camera.main.transform.position);
		Physics.Raycast(ray_pos, ray_direction, playerRay_hit,5,cursor_mask);

    //Player Controls for Selecting Objects
	if(Input.GetMouseButtonDown(0))
	{
	  if(playerRay_hit != null)
	  {
	   if(playerRay_hit.collider != null)
	   {
	    // if(playerRay_hit.collider.gameObject.layer == "dynamic_object")
	     //{
	     	playerRay_hit.collider.gameObject.SendMessage("interact");
		    print(playerRay_hit.collider.gameObject.name);
		// }
	   }
	  }  
	}

}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
