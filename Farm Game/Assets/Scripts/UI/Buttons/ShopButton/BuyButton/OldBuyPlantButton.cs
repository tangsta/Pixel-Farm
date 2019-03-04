	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBuyPlantButton : MonoBehaviour
{	
	/*
		Script works in pairs with PlantDisplay component
		that means this script and PlantDisplay have to be on the same
		buy button
	*/
	// Plant plantInfo;
	// private int maxInventorySize;

	// void Start()
	// {
	// 	plantInfo = this.gameObject.GetComponent<PlantDisplay>().plant;

	// 	// instead of getting the inventory from gamemanager, we should get the new scriptbale object from assest 
	// 	maxInventorySize = GameObject.Find("GameManager").GetComponent<InventoryScript>().maxInventorySize;
	// }


	// // add a conditional where the golds cost can not be highest than the golds currently
	// // issues here - we can referencing alot so runtime might slow down
	// public void BuyPlant()
	// {
	// 	if(plantInfo.goldCost <= GameObject.Find("GameManager").GetComponent<PlayerData>().gold)
	// 	{	
	// 		// calculate new golds
	// 		GameObject.Find("GameManager").GetComponent<PlayerData>().gold -= plantInfo.goldCost;


	// 		// Looks for GameManager and then saves the plantInventory to this variable
	// 		List<Plant> plantInventory = GameObject.Find("GameManager").GetComponent<InventoryScript>().plantInventory;

	// 		// Gets the current plant that the user clicked on and saves tit's name
	//     	Plant plant = this.gameObject.GetComponent<PlantDisplay>().plant;
	//     	string plantName = plant.name;

	//     	// now while loop through the list to find if the plant is in the user's inventory 
	//         if(plantInventory.Find(plantObj => plantObj == plant))
	//         {
	//         	// Debug.Log("inside "+plantInventory.Find(plantObj => plant.name == plantName));
	//         	plantInventory.Find(plantObj => plantObj == plant).amount++;

	//         }
	//         // if plant does not exist then add new plant to inventory 
	//         else if(plantInventory.Count < maxInventorySize)
	//         {
	//         	// adding plant to inventory 
	//         	plantInventory.Add(plant);
	//         	Debug.Log("New plant added");
	//         }
	//         else
	//         {
	//         	Debug.Log("Sorry you are out of space");
	//         }

	//         // saves the new updated inventory back to the GameManager
	//         GameObject.Find("GameManager").GetComponent<InventoryScript>().plantInventory = plantInventory;
	// 	}
	// 	else
	// 	{
	// 		Debug.Log("Sorry you do not have enough");
	// 	}
	// }
}
