using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencePlayerData : MonoBehaviour
{
	[Header("Reference GameManager")]
	public GameObject GameManager;
	public string levelText;
	public string goldText;
	public string gemText;

	PlayerData playerData;
    

    void Start()
    {
    	playerData = GameManager.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
		// levelText = "Level " + GameManager.GetComponent<PlayerData>().level;
		// goldText = "Gold " + GameManager.GetComponent<PlayerData>().gold;
		// gemText = "Gem " + GameManager.GetComponent<PlayerData>().gem;   
		levelText = "Level " + playerData.level;
		goldText = "Gold " + playerData.gold;
		gemText = "Gem " + playerData.gem;  
    }
}
