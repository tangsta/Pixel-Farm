using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBuyPlantButton : MonoBehaviour
{
	/*
		This script will hard coded so all items in the shop can be in whatever order you want
		
		How to use
		----------
		Attach the script to a buy slot
		Drag the desired item that you want to be sold into the script - onto the variable item
		Done 

	*/

	//***************************************************************************
    public ItemInstance itemInstance;
	public Inventory userInventory; 
	
	private Image icon;

	void Awake()
	{
		icon = this.transform.Find("Image").GetComponent<Image>();
		if(itemInstance.item != null)
		{
			icon.sprite = itemInstance.item.artwork;
			icon.enabled = true;
		}
		else
		{
			itemInstance.item = null;
			icon.sprite = null;
			icon.enabled = false;
		}
	}


	// add a conditional where the golds cost can not be highest than the golds currently
	// issues here - we can referencing alot so runtime might slow down
	public void BuyPlant()
	{
		// calculates if the cost of this plant is higher than the amount the player has
		if(itemInstance.item.goldCost <= GameObject.Find("GameManager").GetComponent<PlayerData>().gold)
		{	
			// calculate new golds
			if(userInventory.FindItem(itemInstance))
			{
				GameObject.Find("GameManager").GetComponent<PlayerData>().gold -= itemInstance.item.goldCost;
				userInventory.IncreaseQuantityItem(1,itemInstance);
				// also increase the amount of seeds the user has
			}
			// check if the user ran out of room or add new plant to inventory
			// DOESN'T CHECK IF USER RAN OUT OF ROOM YET 
			else
			{
				userInventory.InsertItem(itemInstance);
				userInventory.IncreaseQuantityItem(1,itemInstance);
				GameObject.Find("GameManager").GetComponent<PlayerData>().gold -= itemInstance.item.goldCost;
			}
		}
		else
		{
			// here tell the user that he does not have enough golds
			Debug.Log("Not enough golds");
		}
	}
}
