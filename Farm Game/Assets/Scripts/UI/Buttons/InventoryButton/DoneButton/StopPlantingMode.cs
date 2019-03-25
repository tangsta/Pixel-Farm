using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlantingMode : MonoBehaviour
{

	public GameObject PlantButton;

	public void StopPlanting()
	{
		PlantButton.GetComponent<PlantButton>().plantingMode = false;
	}
}
