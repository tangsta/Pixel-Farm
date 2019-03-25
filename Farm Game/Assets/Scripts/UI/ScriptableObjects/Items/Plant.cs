using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Plant.asset", menuName = "Items/Plant")]
public class Plant : Item
{
	[Header("Plant Attributes")]
	// required level to buy/plant?
	public string description;
	public int requriedLevel;
	public int amount;
	public int sellPrice;
	public double baseGrowth;

	[Header("Plant Phases")]
	public Sprite[] phases = new Sprite[3];
	// water time should be half of harvestTime

	[Header("Plant Attributes")]
	public Crop crop;
}
