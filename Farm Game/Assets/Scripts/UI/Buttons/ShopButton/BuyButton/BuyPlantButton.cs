using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPlantButton : MonoBehaviour
{
    // add a conditional where the golds cost can not be highest than the golds currently
	

	// get itemInstance from shopcontrol
	// get inventory from shop control
	// check for null	
	
	public ShopControl shopcontrol;
	private ItemInstance itemInstance;
	private Inventory goalInventory;

	public void BuyPlant()
	{
		shopcontrol = transform.parent.gameObject.GetComponent<ShopControl>();
		itemInstance = shopcontrol.currentSelectedItem;
		goalInventory = shopcontrol.goalInventory;


		// calculates if the cost of this plant is higher than the amount the player has
		if(itemInstance != null && goalInventory != null)
		{
			if(itemInstance.item.goldCost <= GameObject.Find("GameManager").GetComponent<PlayerData>().gold)
			{	
				// calculate new golds
				if(goalInventory.FindItem(itemInstance))
				{
					GameObject.Find("GameManager").GetComponent<PlayerData>().gold -= itemInstance.item.goldCost;
					goalInventory.IncreaseQuantityItem(1,itemInstance);
					// also increase the amount of seeds the user has
				}
				// check if the user ran out of room or add new plant to inventory
				// DOESN'T CHECK IF USER RAN OUT OF ROOM YET 
				else
				{
					goalInventory.InsertItem(itemInstance);
					goalInventory.IncreaseQuantityItem(1,itemInstance);
					GameObject.Find("GameManager").GetComponent<PlayerData>().gold -= itemInstance.item.goldCost;
				}
			}
			else
			{
				// here tell the user that he does not have enough golds
				Debug.Log("Not enough golds");
			}
		}
		else
		{
			Debug.Log("You didn't select an item to buy yet");
		}
	}
}
