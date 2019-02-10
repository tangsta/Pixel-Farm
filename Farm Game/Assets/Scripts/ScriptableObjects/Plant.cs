using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
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
