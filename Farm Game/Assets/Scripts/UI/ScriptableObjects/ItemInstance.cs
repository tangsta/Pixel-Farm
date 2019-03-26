
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance {
    // Reference to scriptable object "template".
    public Item item;
    // Object-specific data.
    public int Quantity;


    /* How to use 
    		How to use you need to added the object in manually 
    */
    public ItemInstance(Item item) {
        this.item = item;
    }
}