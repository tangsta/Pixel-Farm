using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHotKey : MonoBehaviour
{
	/*
		Script works in pairs with PlantDisplay component
		that means this script and PlantDisplay have to be on the same
		buy button
	*/
	Plant plantInfo;
    // Start is called before the first frame update
	void Start()
	{
		plantInfo = this.gameObject.GetComponent<PlantDisplay>().plant;
	}

	void PlantSeedFromInventory()
	{
		/*
			
		*/
	}
}
