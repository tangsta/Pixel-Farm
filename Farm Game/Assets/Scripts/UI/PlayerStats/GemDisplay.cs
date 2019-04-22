using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemDisplay : MonoBehaviour
{
	/*
		Placed this component in GemText Object under UI

		Displays the player's gem amount
		All stats changed in GameManager should effect here
	*/
	// Remember to reference the Text Component here 
    public Text gemText;
    ReferencePlayerData PlayerData;

    void Start()
    {
    	ReferencePlayerData PlayerData = this.GetComponentInParent<ReferencePlayerData>();
    }
    // Update is called once per frame
    void Update()
    {
        gemText.text = this.GetComponentInParent<ReferencePlayerData>().gemText;
    }
}
