using UnityEngine;

public class TestClick : MonoBehaviour
{
    public Map Map;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
                                        Mathf.FloorToInt(PointClick.y), 0);

            Map.Water(worldPoint);

            //Obtains from SoilPlot Dictionary
            /*
            if (Map != null)
            {
                if (Map.GetPlant(worldPoint) != null)
                    Debug.Log(Map.GetLand(worldPoint).UpdateState() + " " + Map.GetPlant(worldPoint).State);
                else
                    Debug.Log("Land: "+Map.GetLand(worldPoint).UpdateState());
            }
            */
        }
    }
}
