using System;
using UnityEngine;
using System.Collections;


namespace AssemblyCSharpfirstpass
{
   public class Interactions : MonoBehaviour
   {
      int           interactble_layer;
      HintDisplay   hint_display;

      static readonly float RAY_LENGTH = 3;

      // Interactable objects.
      private const string TABLE_STAND = "NightStand";
      private const string HALLWAY_CLOCK = "Clock";
      private const string HALLWAY_DOOR = "Door";


      void Start()
      {
         // Define the different layers used for this level. Shift the bits of
         // the layer mask based on the position of the layers.
         interactble_layer = 1 << 9;

         hint_display = (HintDisplay)this.GetComponent("HintDisplay");        
      }

      public void interact(Vector3 rayDirection, Vector3 rayPosition)
      {
         RaycastHit   rayHit;
         GameObject   gameObject;

         // Check if they ray has collided with any of the layers.
         if (Physics.Raycast(rayPosition, rayDirection, out rayHit, RAY_LENGTH,
             interactble_layer))
         {
            // Find out which object was detected for this layer.
            gameObject = rayHit.collider.gameObject;
            if (gameObject.CompareTag(TABLE_STAND))
            {
               hint_display.showHint("[E] Open");
               if (Input.GetKeyDown(KeyCode.E))               
                  rayHit.collider.gameObject.SendMessage("interact");
            }
            else if (gameObject.CompareTag(HALLWAY_CLOCK))
            {
               hint_display.showHint("[E] Interact");
               if (Input.GetKeyDown(KeyCode.E))
                  rayHit.collider.gameObject.SendMessage("interact");
            }
            else if (gameObject.CompareTag(HALLWAY_DOOR))
            {
               hint_display.showHint ("[E] Open");
               if (Input.GetKeyDown(KeyCode.E))
                  rayHit.collider.gameObject.SendMessage("interact");
            }
				
         }
         else
         {
            // Nothing collided with the ray so turn off hints.
            hint_display.hideHint();
         }
      }
   }
}