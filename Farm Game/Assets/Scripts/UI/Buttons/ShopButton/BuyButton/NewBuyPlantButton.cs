using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Item item;
	public Inventory userInventory; 



	void Start()
	{

	}


	// add a conditional where the golds cost can not be highest than the golds currently
	// issues here - we can referencing alot so runtime might slow down
	public void BuyPlant()
	{
		// calculates if the cost of this plant is higher than the amount the player has
		if(item.goldCost <= GameObject.Find("GameManager").GetComponent<PlayerData>().gold)
		{	
			// calculate new golds
			GameObject.Find("GameManager").GetComponent<PlayerData>().gold -= item.goldCost;

			// Gets the current plant that the user clicked on and saves it's name
			// for(int x = 0; x < userInventory.inventory.length(); x++)
			// {
			// 	if(GetItem(x, item) == true)
			// 	{
			// 		break;
			// 	}
			// }


	    	// now while loop through the list to find if the plant is in the user's inventory 

	        // if plant does not exist then add new plant to inventory 
	        	// adding plant to inventory 

	        // else out of space
		}
	}
}
