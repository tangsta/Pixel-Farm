using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectInventoryItem : MonoBehaviour
{
	// How to use: add onto InventorySlot gameobject 
	// Purpose 
 	
 	private GameObject InventoryUI; // you can just go up the hierachy tree and get the parent 
 	// get the inventoryUI conponent and then change the currently select object value 
 	
 	private InventorySlot inventorySlot;
 	// get the item and send it to the inventory.getconponent<inventoryUI>.item = item;

	public void SelectThisItem()
	{
		inventorySlot = this.gameObject.GetComponent<InventorySlot>();
		InventoryUI = transform.parent.parent.gameObject;
		InventoryUI.GetComponent<InventoryUI>().currentSelectedItem = inventorySlot.item;
	}
}
