using UnityEngine;
using System.Collections;


public class HintDisplay : MonoBehaviour
{
	Rect     hint_position;
	string   hint_text;
   bool     show_hint;
	
   
	void Start()
	{
		int   width;
		int   height;

		// Default size and position of rectangle that encompasses the label.
		width = 250;
		height = 20;		
		hint_position = new Rect((Screen.width - width)/2, (Screen.height - height)/2, width, height);

      // Default values.
		hint_text = "";
      show_hint = false;
	}
	

	// Update is called once per frame.
	void Update()
	{
	}
	

	void OnGUI()
	{
      // Display the hint.
      if (show_hint)
         GUI.Label(hint_position, hint_text);
   }


   public void setHint(string hint)
   {
	   hint_text = hint;
   }


	public void setHint(string hint, int time)
	{
	   // Show this hint for the specified amount of time.
		hint_text = hint;
   }


   public void hideHint()
   {
	   show_hint = false;
   }


   public void showHint()
   {
      show_hint = true;
   }


   public void showHint(string hint)
   {
      show_hint = true;
      hint_text = hint;
   }


	public void setPosition(float x, float y)
	{
      hint_position.x = x;
      hint_position.y = y;
	}


   public void setSize(float width, float height)
   {
      hint_position.width = width;
      hint_position.height = height;
   }
}
