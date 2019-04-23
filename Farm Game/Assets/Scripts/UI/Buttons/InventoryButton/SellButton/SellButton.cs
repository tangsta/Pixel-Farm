using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
	private InventoryUI inventoryUI;
	public GameObject GameManager;
	private Item currentSelectedItem;
    // Start is called before the first frame update

    public void Sell()
    {
    	inventoryUI = this.gameObject.transform.parent.GetComponent<InventoryUI>();
    	currentSelectedItem = this.gameObject.transform.parent.GetComponent<InventoryUI>().currentSelectedItem;

    	if(currentSelectedItem != null)
    	{
    		ItemInstance currentItemInstance = new ItemInstance(currentSelectedItem);

    		if(inventoryUI.userInventory.FindItem(currentItemInstance))
    		{
    			inventoryUI.userInventory.DecreaseQuantityItem( 1, currentItemInstance );
    			GameManager.GetComponent<PlayerData>().gold += currentSelectedItem.sellPrice;
    		}
    		this.gameObject.transform.parent.GetComponent<InventoryUI>().UpdateUI();
    	}
    	else
    	{
    		Debug.Log("Current item want to sell is null");
    		this.gameObject.transform.parent.GetComponent<InventoryUI>().UpdateUI();
    	}
    }
}
