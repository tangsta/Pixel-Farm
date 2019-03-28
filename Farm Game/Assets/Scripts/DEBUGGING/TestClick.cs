using UnityEngine;

public class TestClick : MonoBehaviour
{
    public SceneData Scene;
    private GroundStats ground;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
                                        Mathf.FloorToInt(PointClick.y), 0);

            var soilPlots = Scene.Grounds;

            //Obtains from SoilPlot Dictionary
            if (soilPlots.TryGetValue(worldPoint, out ground))
            {
                Debug.Log(ground.Type + " " + ground.Sand + " " + ground.Silt + " " + ground.Clay);
            }
        }
    }
}
