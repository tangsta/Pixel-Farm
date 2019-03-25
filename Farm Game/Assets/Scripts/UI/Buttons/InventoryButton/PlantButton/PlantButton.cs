using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantButton : MonoBehaviour
{

	public GameObject Inventory; // this will give us the reference we need to start planting 
	public Item item;
	public Plant plant;

	public GameObject Grid; // used to get function
	public Crop crop; // how to get a crop??

	//for clicking
    private GroundStats ground;


	public void Plant()
	{
		item = Inventory.GetComponent<InventoryUI>().currentSelectedItem;
		plant = (Plant) item;
		crop = plant.crop ;
		
		if (Input.GetMouseButtonUp(0))
        {
            Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
                                        Mathf.FloorToInt(PointClick.y), 0);

            Debug.Log("hello");
            Grid.GetComponent<CropMap>().SpawnCrop(PointClick, plant.crop );
		}
	}
}
