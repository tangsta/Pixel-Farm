using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
	/*
		Placed this component in GoldText Object under UI

		Displays the player's gold amount
		All stats changed in GameManager should effect here
	*/
	// Remember to reference the Text Component here 
    public Text goldText;
    ReferencePlayerData PlayerData;

    void Start()
    {
    	ReferencePlayerData PlayerData = this.GetComponentInParent<ReferencePlayerData>();
    }

    void Update()
    {
        goldText.text = this.GetComponentInParent<ReferencePlayerData>().goldText;
    }
}
