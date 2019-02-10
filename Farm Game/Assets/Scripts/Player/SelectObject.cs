using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectObject : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject plantButton;

    void Update()
    {
        // this top function works for PC/Mobile however only one finger will work
        // selects the gameobject that the user wants to fiddle with
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
            	/*
					Work on this too - add an outline on gameobjects if they are click or only plots
            	*/
                Debug.Log(hit.collider.gameObject.name);
                selectedObject = hit.collider.gameObject;
                selectedObject.AddComponent<UnityEngine.UI.Outline>();
                // EffectColor should change
            }
            else
            {
                selectedObject = null;
            }
        }


        if(Input.GetMouseButtonUp(0))
        {
	        /*
	        	Shows the plant button if a plot is selected
	        	
	        	Bug - you try to click the button but the button disappear before you register  
			*/
	        if(selectedObject != null && selectedObject.tag =="Plot")
	        {
	        	plantButton.SetActive(true);
	        	// Debug.Log("Plot selected");
	        }
	        else
	        {
	        	plantButton.SetActive(false);
	        }
        }



        // for now we can't do touchCount because we require a android phone
        // touchCount will always remain 0
        if ((Input.touchCount > 0))
        {

            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Hit");

                if (raycastHit.collider.CompareTag("Plot"))
                {
                    Debug.Log("Soccer Ball clicked");
                }
            }
        }
    }
}
