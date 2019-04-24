using UnityEngine;

public class TestClick : MonoBehaviour
{
    public Map Map;
    public MINIGAMEQUICKIE FIX;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
                                        Mathf.FloorToInt(PointClick.y), 0);
            if (!FIX.FIX)
                Map.Play(worldPoint);
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
