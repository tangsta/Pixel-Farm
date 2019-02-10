using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantDisplay : MonoBehaviour
{
	/*
		Script works in pairs with BuyPlantButton component
		that means this script and BuyPlantButton have to be on the same
		buy button
	
		This templete is used with Scriptable Obejects created 
		in the Prefab/Plant/* folder
	*/
		
	// Takes in a Scriptable Object called plant
	public Plant plant;

	// public Text nameText;
	// public Text descriptionText;

	public Image artworkImage;

/*	public Text requiredLevelText;
	public Text goldText;
	public Text harvestTime;*/

	void Start()
	{
		// nameText.text = plant.plantName;
		// descriptionText.text = plant.description;

		artworkImage.sprite = plant.artwork;
		// requiredLevelText.text = plant.requriedLevel.ToString();
		// goldText.text = plant.goldCost.ToString();
		// harvestTime.text = plant.harvestTime.ToString();
	}
}
