using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject {
	[Header("Item Attributes")]
	public string itemName;
	public string description;
    public Sprite artwork;
	public int goldCost;
	public int sellPrice;
}
