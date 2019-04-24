using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySeedCount : MonoBehaviour
{
	public GameObject seedInventoryGameObject;
	public Inventory seedInventory;
	public Item currentSelectedItem;

	void Update()
	{
		seedInventory = seedInventoryGameObject.GetComponent<InventoryUI>().userInventory;
		currentSelectedItem = seedInventoryGameObject.GetComponent<InventoryUI>().currentSelectedItem;
		ItemInstance ItemInstance = new ItemInstance(currentSelectedItem);
		if(currentSelectedItem != null)
		{
			if(seedInventory.FindItem(ItemInstance))
			{
				this.gameObject.transform.GetChild(0).GetComponent<Text>().text = ""+seedInventory.GetQuantity(ItemInstance);
			}
		}
	}

}
