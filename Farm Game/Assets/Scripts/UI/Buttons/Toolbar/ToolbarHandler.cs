/*  Last Edit:  [4/16/2019] - Henry Tang
 *  Reason:     Added documentation
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *  
 *      
 *  CLASS PURPOSE:
 *      Keep track of all UI that the user can open so we can
 *			- Open close which one we want 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarHandler : MonoBehaviour
{


	GameObject[] UIDisplays; 	// the different UIs (shpo, inventory, etc)
	GameObject[] Tabs;	 		// tabs on the side 
	int active = 0; 			// set default active UI to Shop


	void Awake()
    {
        SetTabs();
        DisplayActiveTab();
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
			Debug.Log(UIDisplays[i-1]);
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
    public void DisplayActiveTab()
    {
    	for(int x = 0; x < UIDisplays.Length; x++)
    	{
    		if(x != active)
    		{
    			UIDisplays[x].transform.localScale = new Vector3(0,0,0);
    		}
    		else
    		{
    			UIDisplays[x].transform.localScale = new Vector3(1,1,1);
    		}
    	}
    }

    public void UpdateActive(int set)
    {
    	active = set;
    	DisplayActiveTab();
    }



    // public void HideToggleFunction()
    // {
    //     Vector3 zero = new Vector3(0, 0, 0);
    //     Vector3 full = new Vector3(0, 0, 0);
    //     if(gameobjectToHideShow.transform.localScale == zero)
    //     {
    //         gameobjectToHideShow.transform.localScale = new Vector3(1, 1, 1);
    //     }
    //     else
    //     {
    //         gameobjectToHideShow.transform.localScale = new Vector3(0, 0, 0);

    //     }    		
    // }

}
