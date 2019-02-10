using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPlantButton : MonoBehaviour
{	
	/*
		Script works in pairs with PlantDisplay component
		that means this script and PlantDisplay have to be on the same
		buy button
	*/
	Plant plantInfo;
	Inventory inventory;
	private int maxInventorySize;

	void Start()
	{
		plantInfo = this.gameObject.GetComponent<PlantDisplay>().plant;
		maxInventorySize = GameObject.Find("GameManager").GetComponent<InventoryScript>().inventory.maxInventorySize;
	}


	// add a conditional where the gold cost can not be highest than the gold currently
	// issues here - we can referencing alot so runtime might slow down
	public void BuyPlant()
	{
		if(plantInfo.goldCost <= GameObject.Find("GameManager").GetComponent<PlayerData>().gold)
		{	
			// calculate new gold
			GameObject.Find("GameManager").GetComponent<PlayerData>().gold -= plantInfo.goldCost;


			// // adding seed to inventory 
			List<Plant> plantInventory = GameObject.Find("GameManager").GetComponent<InventoryScript>().inventory.plantInventory;

			// // this is correct 
	    	Plant plant = this.gameObject.GetComponent<PlantDisplay>().plant;
	    	string plantName = plant.name;

	        if(plantInventory.Find(plantObj => plantObj.name == plant.name))
	        {
	        	// Debug.Log("inside "+plantInventory.Find(plantObj => plant.name == plantName));
	        	plantInventory.Find(plantObj => plantObj.name == plant.name).amount++;

	        }
	        else if(plantInventory.Count < maxInventorySize)
	        {
	        	plantInventory.Add(Instantiate(plant));
	        	Debug.Log("New plant added");
	        }
	        else
	        {
	        	Debug.Log("Sorry you are out of space");
	        }

	        GameObject.Find("GameManager").GetComponent<InventoryScript>().inventory.plantInventory = plantInventory;
		}
		else
		{
			Debug.Log("Sorry you do not have enough");
		}
	}
}
