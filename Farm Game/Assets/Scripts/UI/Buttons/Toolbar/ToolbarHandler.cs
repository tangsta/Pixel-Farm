/*  Last Edit:  [4/16/2019] - Henry Tang
 *  Reason:     Added documentation
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *  
 *      
 *  CLASS PURPOSE:
 *      Keep track and switch between UI's (shop, inventory) 
 *			- Open/close which one we want
 *  
 *  NOTES:
 * 		You must have a *Button* under the Toolbar gameObject and a *UI panel/gameObject* under Container 		
 *  
 *       
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarHandler : MonoBehaviour
{

	private GameObject[] UIDisplays; 	// the different UIs (shpo, inventory, etc)
	private GameObject[] Tabs;	 		// tabs on the side 
	private int active = 0; 			// set default active UI to Shop

	void Awake()
    {	
        SetTabs();
        DisplayActiveUI();
    }

    public void SetTabs()
    {

    	// UI ****************
    	int UIChildren = this.gameObject.transform.parent.childCount;
    	UIDisplays = new GameObject[UIChildren-1];

    		// start at 1 to skip the toolbar gameobject
		for (int i = 1; i < UIChildren; i++)
		{
			UIDisplays[i-1] = this.gameObject.transform.parent.GetChild(i).gameObject;
			// Debug.Log(UIDisplays[i-1]);
		}


		// tabs ***************
		int TabChildren = this.transform.childCount;
    	Tabs = new GameObject[TabChildren];

		for (int i = 0; i < TabChildren; ++i)
		{
			Tabs[i] = this.gameObject.transform.GetChild(i).gameObject;
			// Debug.Log(Tabs[i]);
		}
    }

    // close all tabs that is not active
    // checks to make sure active is never 0 because 0 is the toolhander
    public void DisplayActiveUI()
    {
    	for(int i = 0; i < UIDisplays.Length; i++)
    	{
    		if(i != active)
    		{
    			UIDisplays[i].transform.localScale = new Vector3(0,0,0);
    		}
    		else
    		{
    			if(UIDisplays[i].GetComponent<InventoryUI>() != null)
    			{
    				UIDisplays[i].GetComponent<InventoryUI>().UpdateUI();
    			}
    			UIDisplays[i].transform.localScale = new Vector3(1,1,1);
    		}
    	}
    }

    public void UpdateActive(int set)
    {
    	active = set;
    	DisplayActiveUI();
    }

}
