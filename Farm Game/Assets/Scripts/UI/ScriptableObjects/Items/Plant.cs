using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Plant.asset", menuName = "Items/Plant")]
public class Plant : Item
{
	public string plantName;
	public string description;

	public Sprite artwork;
	
	[Header("Attributes")]
	// required level to buy/plant?
	public int requriedLevel;
	public int amount;
	public int goldCost;
	public int sellPrice;
	[Header("Seconds")]
	public double harvestTime;
	// water time should be half of harvestTime
}
