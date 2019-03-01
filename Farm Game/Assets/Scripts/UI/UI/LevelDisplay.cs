using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
	/*
		Placed this component in LevelText Object under UI

		Displays the player's level amount
		All stats changed in GameManager should effect here
	*/
	// Remember to reference the Text Component here 
    public Text levelText;
    ReferencePlayerData PlayerData;

    void Start()
    {
    	ReferencePlayerData PlayerData = this.GetComponentInParent<ReferencePlayerData>();
    }
    // Update is called once per frame
    void Update()
    {
        levelText.text = this.GetComponentInParent<ReferencePlayerData>().levelText;
    }
}
