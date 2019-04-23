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
        // gets all the slots 
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }



    /* 
        Call this function to update UI 

        Way One (Buttons) - '+' another command then add the desired GameObject with this script onto the Object box
                            then select this function from the dropdown list  
        
    
    */
    public void UpdateUI()
    {
    	for(int i = 0; i < slots.Length; i++)
    	{
    		if(userInventory.inventory[i] != null)
    		{
    			slots[i].AddItem(userInventory.inventory[i].item);
    		}
    		else
    		{
                Debug.Log("Yo");
    			slots[i].ClearSlot();
    		}
    	}
    }
}
