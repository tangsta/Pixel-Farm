using UnityEngine;
using UnityEngine.Tilemaps;

public class LandPlot : MonoBehaviour
{
    public byte Sand { get; set; }
    public byte Silt { get; set; }
    public byte Clay { get; set; }
    public byte OrgScore { get; set; }

    public string Name { get; set; }
    public TileBase Tile { get; set; }  
    public Vector3Int LocalPlace { get; set; }
    public Vector3 WorldLocation { get; set; }

    public LandPlot()
    {
        Sand = 0;
        Silt = 0;
        Clay = 0;
        OrgScore = 0;
    }

    public void Update()
    {
        UpdateTile();
    }

    //Updates the tiles according to land attributes
    private void UpdateTile()
    {
        int total = Sand + Silt + Clay;

        float perSand = 0;
        float perSilt = 0;
        float perClay = 0;
 
        if (total < 125)
        {
            Debug.Log("Stone");
        }
        else
        {
            perSand = Sand / total;
            perSilt = Silt / total;
            perClay = Clay / total;

            if (perClay >= 0.40)
            {
                Debug.Log("Clay");
            }
            else if (perSilt >= 0.80)
            {
                Debug.Log("Silt");
            }
            else if (perSand >= 0.90)
            {
                Debug.Log("Sand");
            }
            else if ((perSilt < 0.30) && (perClay < 0.40 && perSand > 0.50))
            {
                Debug.Log("Sand_Clay");
            }
            else if ((perSand < 0.30) && (perClay < 0.40 && perSilt > 0.50))
            {
                Debug.Log("Silt_Clay");
            }
            else if ((perClay < 0.10) && (perSilt > 0.30 && perSand < 0.70))
            {
                Debug.Log("Sand_Silt");
            }
            else
            {
                Debug.Log("Loam");
            }
        }
    }
}
