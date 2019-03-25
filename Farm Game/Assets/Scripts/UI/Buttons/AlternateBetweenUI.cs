using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlternateBetweenUI : MonoBehaviour
{




	public GameObject shopPanel;
	public GameObject inventoryPanel;
    public bool toggle = true;

    public void AlternateFunction()
    {
    	// isShowing = !isShowing;
		// thisButton.SetActive(isShowing) ;
    	if(toggle)
    	{
            toggle = false;
    		shopPanel.transform.localScale = new Vector3(0, 0, 0);
    		inventoryPanel.transform.localScale = new Vector3(1, 1, 1);
    	}
    	else
    	{
            toggle = true;
    		shopPanel.transform.localScale = new Vector3(1, 1, 1);
            inventoryPanel.transform.localScale = new Vector3(1, 1, 1);
    	}
    }
}
