using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShopItem : MonoBehaviour
{
    // How to use: add onto ShopSlot *button* gameobject 
	// Purpose 
 	
 	private GameObject ShopUI; // you can just go up the hierachy tree and get the parent 
 	// get the inventoryUI conponent and then change the currently select object value 
 	
 	private SetShopSlot shopSlot;
 	// get the item and send it to the ShopControl.cs

	public void SelectThisItem()
	{
		shopSlot = this.gameObject.GetComponent<SetShopSlot>();
		ShopUI = transform.parent.parent.gameObject;

		ShopUI.GetComponent<ShopControl>().currentSelectedItem = shopSlot.itemInstance;
		ShopUI.GetComponent<ShopControl>().goalInventory = shopSlot.goalInventory;
	}
}
