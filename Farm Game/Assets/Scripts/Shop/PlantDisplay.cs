using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
	This templete is used with Scriptable Obejects created 
	in the Prefab/Plant/* folder
*/
public class PlantDisplay : MonoBehaviour
{
	// Takes in a Scriptable Object 
	public Plant plant;

	public Text nameText;
	public Text descriptionText;

	public Image artworkImage;

	public Text requiredLevelText;
	public Text goldText;
	public Text harvestTime;

	void Start()
	{
		nameText.text = plant.plantName;
		descriptionText.text = plant.description;

		artworkImage.sprite = plant.artwork;
		requiredLevelText.text = plant.requriedLevel.ToString();
		goldText.text = plant.goldCost.ToString();
		harvestTime.text = plant.harvestTime.ToString();

	}
}
