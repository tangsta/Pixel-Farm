using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUIButton : MonoBehaviour
{

	/*
		Place this script on any button that you want to toggle the shop with
		remember to link it with the button and use the function below

		shopButton - requires you to link the shop canvas to toggle the button
	*/
	public GameObject thisButton;
	private bool isShowing = false;

    public void ToggleShopFunction()
    {
    	isShowing = !isShowing;
		thisButton.SetActive(isShowing) ;
    }
}
