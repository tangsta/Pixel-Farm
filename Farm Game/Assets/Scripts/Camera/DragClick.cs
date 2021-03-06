﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragClick : MonoBehaviour
{
	private Vector3 ResetCamera;
	private Vector3 Origin;
    private Vector3 Diference;
	private bool Drag = false;
    public Map Map;
    public MINIGAMEQUICKIE fix;

	void Start () {
        Vector3 mid = new Vector3(Map.Width / 2, Map.Height / 2, Camera.main.transform.position.z);
        Camera.main.transform.position = mid;
		ResetCamera = Camera.main.transform.position;
	}
	void LateUpdate () {
		if (Input.GetMouseButton (0) && !fix.FIX) {
			Diference = (Camera.main.ScreenToWorldPoint (Input.mousePosition))- Camera.main.transform.position;
			if (Drag == false){
				Drag = true;
				Origin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
		} else {
			Drag = false;
		}
		if (Drag == true && !fix.FIX){
            Vector3 result = Origin - Diference;
            if (result.x >= -2 && result.x <= Map.Width+2 && result.y >= -2 && result.y <= Map.Height+2)
            { 
                Camera.main.transform.position = result;
            }
            else
            {
                Drag = false;
            }
		}
		//RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
		if (Input.GetMouseButton (1)) {
			Camera.main.transform.position = ResetCamera;
		}
	}
}