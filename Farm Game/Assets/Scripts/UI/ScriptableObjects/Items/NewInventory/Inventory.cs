using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Inventory.asset", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject 
{
    // Saving using unity dev example.
    private static Inventory _instance;
    public static Inventory Instance 
    {
        get 
        {
            if (!_instance) 
            {
                Inventory[] tmp = Resources.FindObjectsOfTypeAll<Inventory>();
                if (tmp.Length > 0) 
                {
                    _instance = tmp[0];
                    Debug.Log("Found inventory as: " + _instance);
                } else 
                {
                    Debug.Log("Did not find inventory, loading from file or template.");
                    SaveManager.LoadOrInitializeInventory();
                }
            }
            return _instance;
        }
    }

    public static void InitializeFromDefault() 
    {
        if (_instance) DestroyImmediate(_instance);
        _instance = Instantiate((Inventory) Resources.Load("InventoryTemplate"));
        _instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public static void LoadFromJSON(string path) 
    {
        if (_instance) DestroyImmediate(_instance);
        _instance = ScriptableObject.CreateInstance<Inventory>();
        JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(path), _instance);
        _instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public void SaveToJSON(string path) 
    {
        Debug.LogFormat("Saving inventory to {0}", path);
        System.IO.File.WriteAllText(path, JsonUtility.ToJson(this, true));
    }

    /* Inventory START */
    	// honestly I just make a new object and store it into the array
    	// ex/ ItemInstance item = new ItemInstance(item);
    public ItemInstance[] inventory;

    public bool SlotEmpty(int index) 
    {
        if (inventory[index] == null || inventory[index].item == null)
            return true;

        return false;
    }

    // Find an item in the inventory array
    public bool FindItem(ItemInstance itemInstance)
    {
        for(int x = 0; x < inventory.Length; x++)
        {
            if(!SlotEmpty(x))
            {
                if(inventory[x].item.itemName == itemInstance.item.itemName)
                {
                    return true;
                }
            }    
        }
        return false;
    }

    // Increase the Quanity of an item 
    public void IncreaseQuantityItem(int amount, ItemInstance itemInstance)
    {
        for(int x = 0; x < inventory.Length; x++)
        {
            if(!SlotEmpty(x))
            {
                if(inventory[x].item.itemName == itemInstance.item.itemName)
                {
                	Debug.Log(inventory[x].item.itemName);
                    inventory[x].Quantity += amount;
                    break;
                }
            }    
        }
    }

    public bool DecreaseQuantityItem(int amount, ItemInstance itemInstance)
    {
        for(int x = 0; x < inventory.Length; x++)
        {
            if(!SlotEmpty(x))
            {
                if(inventory[x].item.itemName == itemInstance.item.itemName)
                {
                	if(inventory[x].Quantity > 0)
                	{
                    	inventory[x].Quantity -= amount;
                    	if(inventory[x].Quantity == 0)
                    	{
                    		RemoveItem(x);
                    	}
                    	return true;
                	}
                	else
                	{
                		return false;
                	}
                }
            }
        }
        return false; // false means item wasn't found or the Quantity was 0
    }

    // Get an item if it exists.
    public bool GetItem(int index, out ItemInstance item) 
    {
        // inventory[index] doesn't return null, so check item instead.
        if (SlotEmpty(index)) 
        {
            item = null;
            return false;
        }

        item = inventory[index];
        return true;
    }

    // Remove all of an item at an index if one exists at that index.
    public bool RemoveItem(int index) 
    {
        if (SlotEmpty(index)) 
        {
            // Nothing existed at the specified slot.
            return false;
        }

        inventory[index] = null;

        return true;
    }

    // Insert an item, return the index where it was inserted.  -1 if error.
    public int InsertItem(ItemInstance item) 
    {
        for (int i = 0; i < inventory.Length; i++) 
        {
            if (SlotEmpty(i)) 
            {
                inventory[i] = item;
                return i;
            }
        }

        // Couldn't find a free slot.
        return -1;
    }

    // Simply save.
    private void Save() 
    {
        SaveManager.SaveInventory();
    }
}