using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetShopSlot : MonoBehaviour
{
	/*
		This script will hard coded so all items in the shop can be in whatever order you want
		
		How to use
		----------
		Attach the script to a buy slot
		Drag the desired item that you want to be sold into the script - onto the variable called 'item'
		Done 

	*/

	//***************************************************************************
    public ItemInstance itemInstance; // the ItemInstance was added in manually 
	public Inventory goalInventory; 

	// each shop button should set the currently selected object 

	// keep the buyplant function below and add a check if statement to see if what is currently selected 
		// go up the parent's parent to check if the that is null or object select




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

}
