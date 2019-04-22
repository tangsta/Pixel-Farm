using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

	public GameObject Grid; // used to get function
    public PlantHandler plantHandler; // reference all the plants in the game

    [Header("Target Inventory")]
    public Inventory ProduceInventory;
    void Update()
    {
        HarvestOrWater();
    }

    void HarvestOrWater()
    {
    	if (Input.GetMouseButtonDown(0))
        {
            // Getting int point in the world
        	Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
                                        Mathf.FloorToInt(PointClick.y), 0);

            // Donny Edits - Plant check is done within structure 
            Grid.GetComponent<Map>().Water(worldPoint); // water function
            if(Grid.GetComponent<Map>().GetPlant(worldPoint) != null)
            {
                Plant clickedPlant = Grid.GetComponent<Map>().GetPlant(worldPoint);
                if(Grid.GetComponent<Map>().Harvest(worldPoint) != -1) // harvest function
                {
                    Crop itemCrop = clickedPlant.GetPlantDef().Crop;
                    ItemInstance CropToItemInstance = new ItemInstance(itemCrop);
                    ProduceInventory.IncreaseQuantityItem(1,CropToItemInstance);
                }
            } 
		}
    }
}
