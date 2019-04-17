using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

	public GameObject Grid; // used to get function
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HarvestOrWater();
    }

    void HarvestOrWater()
    {
    	if (Input.GetMouseButtonDown(0))
        {
        	Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
                                        Mathf.FloorToInt(PointClick.y), 0);

            // checks if a plant is in the same spot - true = no plant || false = plant
            if(Grid.GetComponent<CropHandler>().CheckPlant(worldPoint)) // check if a plant is there
            {
            	// Debug.Log("Is plant");
                Grid.GetComponent<CropHandler>().Water(worldPoint); // water function
                Grid.GetComponent<CropHandler>().HarvestCrop(worldPoint); // harvest function
            }
            else
            {
            	// Do nothing because there is no plant
            }
		}
    }
}
