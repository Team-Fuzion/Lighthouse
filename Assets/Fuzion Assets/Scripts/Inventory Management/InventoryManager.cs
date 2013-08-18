using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InventoryManager : MonoBehaviour
{
   private List<GameObject>   item_list;


   void Awake()
   {
      // Inventory list.
      item_list = new List<GameObject>();
   }


   public void addItem(GameObject item)
   {
      // New item in the inventory.
      item_list.Add(item);
   }


   public GameObject removeItem(GameObject item)
   {
      GameObject   itemRemoved;

      // Make sure that the item exists before removing it.
      itemRemoved = checkForItem(item);
      if (itemRemoved != null)
      {
         item_list.Remove(item);
         return item; //TODO: make sure that item still exists after removing.
      }
      else
      {
         // Item being removed from the inventory does not exist.
         Debug.LogError("Attempted to remove an item not found in the " +
                        "inventory.");
         return null;
      }
   }


   public GameObject checkForItem(GameObject item)
   {
      // Check to see if the item specified is in the list. Will return null
      // if none is found.
      return item_list.Find(itemObject => itemObject.CompareTag(item.tag));
   }


   public int getCount()
   {
      // Get the number of items currently stored in inventory.
      return item_list.Count;
   }
}
