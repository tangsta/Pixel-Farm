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
	public double harvestTime;
	// water time should be half of harvestTime
}
