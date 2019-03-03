using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{


	public Image icon;
	Item plant; // this only takes in plants so you have to redo this later to accept any item like decos

	public void AddItem(Item newPlant)
	{
		if(newPlant != null)
		{
			plant = newPlant;
			icon.sprite = plant.artwork;
			icon.enabled = true;
		}
	}

	public void ClearSlot()
	{
		plant = null;
		icon.sprite = null;
		icon.enabled = false;
	}

}
