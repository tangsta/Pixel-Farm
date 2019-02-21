using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDirtSquares : MonoBehaviour
{

    // want to create a 3x3 for plots 
    public GameObject freePlot;
    GameObject[,] plots = new GameObject[3,3];


    // Start is called before the first frame update
    void Start()
    {
        // fill the plots with predefine free spots 
        for (int y = 0; y < plots.GetLength(0); y++)
        {
            for (int x = 0; x < plots.GetLength(1); x++)
            {
                Vector3 pos = new Vector3(this.gameObject.transform.position.x + (x*3), this.gameObject.transform.position.y + (y*3), this.gameObject.transform.position.z);
                plots[x, y] = freePlot;
                GameObject child = Instantiate(plots[x, y], pos, this.gameObject.transform.rotation);
                child.transform.parent = this.transform;
            }
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
