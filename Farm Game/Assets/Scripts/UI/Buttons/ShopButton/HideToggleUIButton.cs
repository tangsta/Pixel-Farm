using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideToggleUIButton : MonoBehaviour
{

	/*
		Place this script on any button that you want to toggle the shop with
		remember to link it with the button and use the function below

		shopButton - requires you to link the shop canvas to toggle the button
	*/
	public GameObject gameobjectToHideShow;
    public bool toggle = true;
    public void HideToggleFunction()
    {
    	if(toggle)
    	{
            toggle = false;
    		gameobjectToHideShow.transform.localScale = new Vector3(0, 0, 0);
    	}
    	else
    	{
            toggle = true;
    		gameobjectToHideShow.transform.localScale = new Vector3(1, 1, 1);
    	}
    }
}
