using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragClick : MonoBehaviour
{
	private Vector3 ResetCamera;
	private Vector3 Origin;
    private Vector3 Diference;
	private bool Drag = false;
    public Map Map;

	void Start () {
        Vector3 mid = new Vector3(Map.Width / 2, Map.Height / 2, Camera.main.transform.position.z);
        Camera.main.transform.position = mid;
		ResetCamera = Camera.main.transform.position;
	}
	void LateUpdate () {
		if (Input.GetMouseButton (0)) {
			Diference = (Camera.main.ScreenToWorldPoint (Input.mousePosition))- Camera.main.transform.position;
			if (Drag == false){
				Drag = true;
				Origin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
		} else {
			Drag = false;
		}
		if (Drag == true){
            Vector3 result = Origin - Diference;
            if ((result.x < 0 || result.x > Map.Width) && (result.y < 0 || result.y > Map.Height))
            {
                Debug.Log("You cannot drag any further");
            }
            else
            {
                Camera.main.transform.position = result;
            }
		}
		//RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
		if (Input.GetMouseButton (1)) {
			Camera.main.transform.position = ResetCamera;
		}
	}
}