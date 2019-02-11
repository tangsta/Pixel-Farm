using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public GameObject GameManager;
	private List<Plant> plantList; // link the scriptable object inventory here 

	public Transform itemsParent;
	InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        // inventory = Inventory.instance;
        plantList = GameManager.GetComponent<InventoryScript>().plantInventory;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		UpdateUI();
    }

    void Update()
    {
    	        // inventory = Inventory.instance;
        plantList = GameManager.GetComponent<InventoryScript>().plantInventory;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		UpdateUI();
    }

    void UpdateUI()
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
    	Debug.Log("UPDATING UI");
    }

}
