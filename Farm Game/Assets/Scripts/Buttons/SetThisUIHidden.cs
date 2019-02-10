using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetThisUIHidden : MonoBehaviour
{
	/*
		Set the current button to hide once the game starts 
		Can be placed on any buttons
	*/
    GameObject thisUI;
    void Start()
    {
    	thisUI = this.gameObject;
        thisUI.SetActive(false);
    }
}
