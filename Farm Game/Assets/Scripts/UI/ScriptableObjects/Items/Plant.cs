using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Plant.asset", menuName = "Items/Plant")]
public class Plant : Item
{
	/*
		Plant class should be used in inventory only
	*/
	[Header("Plant Attributes")]
	// required level to buy/plant?
	public string description;
	public int requriedLevel;
	public int amount;

	[Header("Plant Attributes")]
	public Crop crop;
}
