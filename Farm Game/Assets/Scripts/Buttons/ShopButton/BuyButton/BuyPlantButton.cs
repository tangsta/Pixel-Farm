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

	void Start()
	{
		plantInfo = this.gameObject.GetComponent<PlantDisplay>().plant;
	}


	// add a conditional where the gold cost can not be highest than the gold currently
	// issues here - we can referencing alot so runtime might slow down
	public void BuyPlant()
	{
		if(plantInfo.goldCost <= GameObject.Find("GameManager").GetComponent<PlayerData>().gold)
		{
			GameObject.Find("GameManager").GetComponent<PlayerData>().gold -= plantInfo.goldCost;
		}
		else
		{
			Debug.Log("Sorry you do not have enough");
		}
	}
}
