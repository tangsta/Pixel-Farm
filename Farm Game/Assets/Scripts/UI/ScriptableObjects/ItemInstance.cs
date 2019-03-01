
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance {
    // Reference to scriptable object "template".
    public Item item;
    public int Quantity;
    // Object-specific data.
    // public Quality.QualityGrade quality;

    public ItemInstance(Item item) {
        this.item = item;
    }
}