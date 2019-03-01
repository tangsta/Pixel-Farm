
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance {
    // Reference to scriptable object "template".
    public Item item;

    // Object-specific data.
    // public Quality.QualityGrade quality;

    public ItemInstance(Item item) {
        this.item = item;
    }
}