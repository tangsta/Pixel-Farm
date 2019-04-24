using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemInInventory : MonoBehaviour
{
	// Place this script on the panel that has all the text objects ex/ SeedInfoPanel

	// should be called everytime a new item is select to update all the text fields

	public InventoryUI inventoryUI;  // to get the current select item
	public Item currentSelectedItem;

	private GameObject[] ImageGameObjects;

	public Text textBox;


	public void DisplayItem()
	{
		inventoryUI = this.gameObject.transform.parent.parent.GetComponent<InventoryUI>();
		currentSelectedItem = inventoryUI.currentSelectedItem;

		

		// Get each Image gameobject so later we can look at their child's Text ****************
    	int numChildren = this.gameObject.transform.childCount;
    	ImageGameObjects = new GameObject[numChildren];

		for (int i = 0; i < numChildren; i++)
		{
			ImageGameObjects[i] = this.gameObject.transform.GetChild(i).gameObject;
			// Debug.Log(ImageGameObjects[i]);
		}
		// ************* Setup complete ***************************

		// Set the name HARD CODED OUT OF ITS MIND - ASK HENRY FOR MAINTENCE 
		textBox = ImageGameObjects[0].transform.GetChild(1).GetComponent<Text>(); // gets the second gameobject which is text of the three gameobjects we saved
		textBox.text = currentSelectedItem.name; 

		textBox = ImageGameObjects[1].transform.GetChild(1).GetComponent<Text>(); // gets the second gameobject which is text of the three gameobjects we saved
		textBox.text = currentSelectedItem.description; 

		textBox = ImageGameObjects[2].transform.GetChild(1).GetComponent<Text>(); // gets the second gameobject which is text of the three gameobjects we saved
		textBox.text = ""+currentSelectedItem.sellPrice + "g"; 
	}
}
