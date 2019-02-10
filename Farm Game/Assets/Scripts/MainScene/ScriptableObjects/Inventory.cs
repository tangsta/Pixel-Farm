using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
	// later make a list of list so you can have different tabs

	// should i make this static who knows
	public List<Plant> plantInventory = new List<Plant>();
	public int maxInventorySize = 20;
}
