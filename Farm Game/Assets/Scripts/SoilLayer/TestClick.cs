using UnityEngine;

public class TestClick : MonoBehaviour
{
    public SoilManager SoilManager;
    private SoilPlot plot;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
                                        Mathf.FloorToInt(PointClick.y), 0);

            var soilPlots = SoilManager.instance.SoilPlots;

            //Obtains from SoilPlot Dictionary
            if (soilPlots.TryGetValue(worldPoint, out plot))
            {
                Debug.Log(plot.Name);
            }
        }
    }
}
