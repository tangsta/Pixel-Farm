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
    public void HideToggleFunction()
    {
        Vector3 zero = new Vector3(0, 0, 0);
        Vector3 full = new Vector3(0, 0, 0);
        if(gameobjectToHideShow.transform.localScale == zero)
        {
            gameobjectToHideShow.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameobjectToHideShow.transform.localScale = new Vector3(0, 0, 0);

        }    		
    }
}
