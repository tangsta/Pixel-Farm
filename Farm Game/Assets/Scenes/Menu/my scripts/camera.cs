using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomcamera : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    

    // Update is called once per frame
    //void Update()
   
    public Transform Area;

    public void Update()
    {
        float height = Area.localScale.y * 100;
        float width = Area.localScale.x * 100;

        float w = Screen.width / width;
        float h = Screen.height / height;

        float ratio = w / h;

        float size = (height / 2) / 100f;

        if (w < h)
            size /= ratio;

        Camera.main.orthographicSize = size;

        Vector2 position = Area.transform.position;

        Vector3 camPosition = position;
        Vector3 point = Camera.main.WorldToViewportPoint(camPosition);
        Vector3 delta = camPosition - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;

        transform.position = destination;
    }

}