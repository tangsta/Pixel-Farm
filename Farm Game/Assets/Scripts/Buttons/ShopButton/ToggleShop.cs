using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShop : MonoBehaviour
{
	private GameObject shopButton;
	private bool isShowing = false;

	void Start()
	{
		shopButton = GameObject.Find("ShopCanvas");
	}

  //   // Update is called once per frame
  //   void Update()
  //   {
		// if (Input.GetKeyDown("escape"))
		// {
		// 	isShowing = !isShowing;
		// 	shopButton.SetActive(false) ;
		// }   
  //   }

    public void ToggleShopFunction()
    {
    	isShowing = !isShowing;
		shopButton.SetActive(isShowing) ;
    }
}
