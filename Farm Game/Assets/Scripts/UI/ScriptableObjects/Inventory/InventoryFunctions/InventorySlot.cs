using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{


	public Image icon;
	public Item item; // this only takes in items so you have to redo this later to accept any item like decos

	public void AddItem(Item initem)
	{
		if(initem != null)
		{
			icon.sprite = initem.artwork;
			icon.enabled = true;
			item = initem;
		}
	}

	public void ClearSlot()
	{
		item = null;
		icon.sprite = null;
		icon.enabled = false;
	}


}
