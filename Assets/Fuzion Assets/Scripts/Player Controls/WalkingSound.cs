using UnityEngine;
using System.Collections;

public class WalkingSound : MonoBehaviour {

	void Start()
	{
		//audio.volume = 0.4
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown ("w") || Input.GetKeyDown("s")|| Input.GetKeyDown("a")|| Input.GetKeyDown("d"))
		{
		  audio.Play(441);
		}
		if(Input.GetKeyUp ("w")||Input.GetKeyUp("s")||Input.GetKeyUp("a")||Input.GetKeyUp("d"))
		{
			Invoke("stopSteps",0);
			
			
		}
	}
	
	void stopSteps()
	{
		audio.Stop();
		
	}
}
