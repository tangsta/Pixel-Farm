using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
	// later make a list of list so you can have different tabs

	// should i make this static who knows
	List<Plant> plantInventory = new List<Plant>();
	public int maxInventorySize;

	
	public Plant plantOne;
	public Plant plantTwo;

    void Start()
    {
        Debug.Log(plantInventory.Count);
        plantInventory.Add(plantOne);
        plantInventory.Add(plantTwo);
		Debug.Log(plantInventory.Count);
        Debug.Log(plantInventory.Contains(plantOne));
    }

    // Update is called once per frame
    void AddSeed(Plant plant)
    {
        
    }
}
