using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{
	public string plantName;
	public string description;

	// required level to buy/plant?
	public int requriedLevel;
	public Sprite artwork;

	public int goldCost;
	[Header("Seconds")]
	public double harvestTime;
	// water time should be half of harvestTime
	


}
