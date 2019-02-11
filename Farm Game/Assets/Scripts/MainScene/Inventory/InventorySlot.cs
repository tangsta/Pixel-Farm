using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{


	public Image icon;
	Plant plant; // this only takes in plants so you have to redo this later to accept any item like decos

	public void AddItem(Plant newPlant)
	{
		plant = newPlant;
		icon.sprite = plant.artwork;
		icon.enabled = true;
	}

	public void ClearSlot()
	{
		plant = null;
		icon.sprite = null;
		icon.enabled = false;
	}

}
