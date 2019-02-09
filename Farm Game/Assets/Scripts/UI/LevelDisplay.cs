using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    private int level = 1;
    public Text levelText;

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level " + level.ToString();

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            level++;
        }
    }
}
