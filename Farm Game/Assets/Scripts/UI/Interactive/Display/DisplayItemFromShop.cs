using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemFromShop : MonoBehaviour
{
    public ShopControl shopControl;  // to get the current select item
	public Item currentSelectedItem;

	private GameObject[] ImageGameObjects;

	public Text textBox;


	public void DisplayItem()
	{
		shopControl = this.gameObject.transform.parent.parent.GetComponent<ShopControl>();
		currentSelectedItem = shopControl.currentSelectedItem.item;

		

		// Get each Image gameobject so later we can look at their child's Text ****************
		if(currentSelectedItem != null)
		{
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
			textBox.text = currentSelectedItem.itemName; 

			textBox = ImageGameObjects[1].transform.GetChild(1).GetComponent<Text>(); // gets the second gameobject which is text of the three gameobjects we saved
			textBox.text = currentSelectedItem.description; 

			textBox = ImageGameObjects[2].transform.GetChild(1).GetComponent<Text>(); // gets the second gameobject which is text of the three gameobjects we saved
			textBox.text = ""+currentSelectedItem.goldCost + "g"; 
		}
		else
		{
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
			textBox.text = "";

			textBox = ImageGameObjects[1].transform.GetChild(1).GetComponent<Text>(); // gets the second gameobject which is text of the three gameobjects we saved
			textBox.text = ""; 

			textBox = ImageGameObjects[2].transform.GetChild(1).GetComponent<Text>(); // gets the second gameobject which is text of the three gameobjects we saved
			textBox.text = ""; 
		}
	}
}
