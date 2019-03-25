using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

	public Transform itemsParent;
    public Inventory userInventory;
    public Item currentSelectedItem;

    // Slots take all the children under the InventoryParent and assigns a plant to it if a plant exist
	InventorySlot[] slots;
    /*
        InventorySlot provides two functions 
            AddItem - takes the plant sciptable object and paste it into the slot attributes
            ClearSlot - turns the image off if there is no item
    */
    void Awake()
    {
        // gets all the slots || change this to the inventory array from the script object
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }


    // For some reason Awake() works better than start lol

    // Updates the UI if the user clicks the switch button
    public void UpdateUI()
    {
    	for(int i = 0; i < slots.Length; i++)
    	{
    		if(userInventory.inventory[i].item != null)
    		{
    			slots[i].AddItem(userInventory.inventory[i].item);
    		}
    		else
    		{
    			slots[i].ClearSlot();
    		}
    	}
    }
}
