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
    	// isShowing = !isShowing;
		// thisButton.SetActive(isShowing) ;
    	if(shopPanel.activeSelf)
    	{
    		Debug.Log("yo");
    		shopPanel.SetActive(false);
    		inventoryPanel.SetActive(true);
    	}
    	else
    	{
    		shopPanel.SetActive(true);
    		inventoryPanel.SetActive(false);
    	}
    }
}
