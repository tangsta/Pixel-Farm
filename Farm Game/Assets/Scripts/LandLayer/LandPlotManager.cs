using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LandPlotManager : MonoBehaviour
{
    public static LandPlotManager instance;
    public Tilemap Tilemap;

    public Dictionary<Vector3, LandPlot> LandPlots;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GetLandPlots();
    }

    private void GetLandPlots()
    {
        LandPlots = new Dictionary<Vector3, LandPlot>();
        foreach(Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            if (!Tilemap.HasTile(localPlace)) continue;
            LandPlot land = new LandPlot
            {
                sand = 175,
                silt = 175,
                clay = 175,
                orgScore = 100,
                tolerance = 25,
                stone = 25,

                LocalPlace = localPlace,
                WorldLocation = Tilemap.CellToWorld(localPlace),
                tile = Tilemap.GetTile<Tile>(localPlace),
                Name = localPlace.x + " , " + localPlace.y,
            };
            LandPlots.Add(land.WorldLocation, land);
        }
    }

}
