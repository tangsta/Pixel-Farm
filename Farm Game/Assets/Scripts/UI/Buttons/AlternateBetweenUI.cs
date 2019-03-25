using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlternateBetweenUI : MonoBehaviour
{




	public GameObject shopPanel;
	public GameObject inventoryPanel;

    public void AlternateFunction()
    {
        Vector3 zero = new Vector3(0, 0, 0);
        Vector3 full = new Vector3(1, 1, 1);
        if(shopPanel.transform.localScale == zero && inventoryPanel.transform.localScale == full)
        {
            shopPanel.transform.localScale = new Vector3(1, 1, 1);
            inventoryPanel.transform.localScale = new Vector3(0, 0, 0);

        }
        else
        {
            shopPanel.transform.localScale = new Vector3(0, 0, 0);
            inventoryPanel.transform.localScale = new Vector3(1, 1, 1);
        } 
    }
}
