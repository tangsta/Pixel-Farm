using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetButtonHidden : MonoBehaviour
{
	/*
		Set the current button to hide once the game starts 
		Can be placed on any buttons
	*/
    GameObject button;
    void Start()
    {
    	button = this.gameObject;
        button.SetActive(false);
    }
}
