﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addbuttons : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform puzzlefield;

    public GameObject btn;

    // Update is called once per frame
    void Awake()
    {
        for(int i=0; i < 18; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzlefield, false);
        }
        
    }
}
