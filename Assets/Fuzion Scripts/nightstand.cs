using UnityEngine;
using System.Collections;

public class nightstand : MonoBehaviour {
	
	Transform tDrawer; 
	GameObject gDrawer;
	static bool open_flag = false;
	static bool in_action = false;
	private Vector3 drawer_speed = Vector3.forward*30;
	private int delay_speed = 1;
	
	void interact()
	{
		
		tDrawer = transform.FindChild ("drawer");
		gDrawer = tDrawer.gameObject;
	 if( !in_action)
	   {
		if(!open_flag)
		{
			//only open the drawer if it is closed (position is local to desk parent)
			//if(tDrawer.localPosition.z <= 0.7)
			//{
		  		Invoke("open",0);
		     	 Invoke("openTostop",delay_speed);
			//}
		//	else
		//	{
		//		open_flag = true;
		//	}
		}
		else if(open_flag)
		{
		
			Invoke ("close",0);
			Invoke ("closeTostop",delay_speed);
			
		}
	  }
	}
	
	void open()
	{
		gDrawer.rigidbody.AddRelativeForce(drawer_speed);
		open_flag = true;
		in_action = true;
	}
	
	void openTostop()
	{
		gDrawer.rigidbody.AddRelativeForce(drawer_speed*-1);
		in_action = false;
	}
	
	void close()
	{
		gDrawer.rigidbody.AddRelativeForce(drawer_speed*-1);
		open_flag = false;	
	}
	
	void closeTostop()
	{
		gDrawer.rigidbody.AddRelativeForce (drawer_speed);
		in_action = false;
	}
	
  
	
}
