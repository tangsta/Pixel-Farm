using UnityEngine;
using UnityEngine.Tilemaps;

public class SoilPlot
{
    public byte Sand { get; set; }
    public byte Silt { get; set; }
    public byte Clay { get; set; }
    public byte OrgScore { get; set; }

    public string Name { get; set; }
    public TileBase Tile { get; set; }  
    public Vector3Int LocalPlace { get; set; }
    public Vector3 WorldLocation { get; set; }

    //Updates the Tile using SoilManager's Tile Array
    public int UpdateTile()
    {
        int total = Sand + Silt + Clay;

        float perSand = 0;
        float perSilt = 0;
        float perClay = 0;
 
        if (total < 125)
        {
            //Stone
            return 0;
        }
        else
        {
            perSand = Sand / total;
            perSilt = Silt / total;
            perClay = Clay / total;

            if (perClay >= 0.40)
            {
                //Clay
                return 1;
            }
            else if (perSilt >= 0.80)
            {
                //Silt
                return 2;
            }
            else if (perSand >= 0.90)
            {
                //Sand
                return 3;
            }
            else if ((perSilt < 0.30) && (perClay < 0.40 && perSand > 0.50))
            {
                //Sand_Clay
                return 4;
            }
            else if ((perSand < 0.30) && (perClay < 0.40 && perSilt > 0.50))
            {
                //Silt_clay
                return 5;
            }
            else if ((perClay < 0.10) && (perSilt > 0.30 && perSand < 0.70))
            {
                //Sand_silt
                return 6;
            }
            else
            {
                //Loam
                return 7;
            }
        }
    }
}
