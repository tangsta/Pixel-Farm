using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShop : MonoBehaviour
{

	/*
		Place this script on any button that you want to toggle the shop with
		remember to link it with the button and use the function below
	*/
	private GameObject shopButton;
	private bool isShowing = false;

	void Start()
	{
		shopButton = GameObject.Find("ShopCanvas");
	}

    public void ToggleShopFunction()
    {
    	isShowing = !isShowing;
		shopButton.SetActive(isShowing) ;
    }
}
