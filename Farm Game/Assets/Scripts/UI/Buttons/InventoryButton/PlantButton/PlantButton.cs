using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 	Purpose
		After a button is clicked the user will enter planting mode and every click will plant something

		*** requires another button to go into this script and turn planting mode to false 	
*/
public class PlantButton : MonoBehaviour
{

	public GameObject Inventory; // reference to Inventory under ShopInventoryCanvas
	public Item item; // store the currentSelectedItem into here 
	private Inventory ScriptableInventory; //  Found under Inventory as one of its public variables 
	private ItemInstance itemInstance; // create an ItemInstance so you can use Inventory functions

	public GameObject Grid; // used to get function
	public Crop crop; // Crop 

	//Donny's script idk what this does or need for 
    private Land ground;

    public bool plantingMode = false;

    // optimize this later
    void Update()
    {
    	if(plantingMode)
    	{
    		if (Input.GetMouseButtonDown(0))
	        {
	        	// we need to check with the inventory if the user has the plant 
	        	item = Inventory.GetComponent<InventoryUI>().currentSelectedItem;
	        	if(item != null)
	        	{
	        		itemInstance = new ItemInstance(item);
	        		if(ScriptableInventory.FindItem(itemInstance))
	        		{
	        			// below spawns the plant according to what was currently selected by the user from the inventory 
						crop = (Crop) item;
			            Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
			                                        Mathf.FloorToInt(PointClick.y), 0);

			            // checks if a plant is in the same spot - true = no plant || false = plant
			            if(Grid.GetComponent<Map>().Plant(worldPoint, crop ))
			            {
			            	ScriptableInventory.DecreaseQuantityItem(1, itemInstance);
			            }
	        		}
	        	}
	        	else if(item == null)
	        	{
	        		// Bug - debug not being called 3/26/2019
	        		Debug.Log("You have no selected an item yet from inventory. Click done and go back.");
	        	}
			}
    	}
    }

	public void Plant()
	{
		plantingMode = true;
		ScriptableInventory = Inventory.GetComponent<InventoryUI>().userInventory;
	}


	// reference the plant button and call this function to activate it 
	public void StopPlanting()
	{
		plantingMode = false;
	}
}
