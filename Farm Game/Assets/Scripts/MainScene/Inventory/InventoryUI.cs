using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

	public GameObject GameManager;
	private List<Plant> plantList; // link the scriptable object inventory here 
	public Transform itemsParent;

	InventorySlot[] slots;
    /*
        InventorySlot provides two functions 
            AddItem - takes the plant sciptable object and paste it into the slot attributes
            ClearSlot - turns the image off if there is no item
    */
    void Awake()
    {
        plantList = GameManager.GetComponent<InventoryScript>().plantInventory;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }


    // For some reason Awake() works better than start lol
  //   void Start()
  //   {
  //       plantList = GameManager.GetComponent<InventoryScript>().plantInventory;
  //       slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		// UpdateUI();
  //   }

    // Updates the UI if the user clicks the switch button
    public void UpdateUI()
    {
    	for(int i = 0; i < slots.Length; i++)
    	{
    		if(i < plantList.Count)
    		{
    			slots[i].AddItem(plantList[i]);
    		}
    		else
    		{
    			slots[i].ClearSlot();
    		}
    	}
    }
}
