using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoilManager : MonoBehaviour // Tilemap
{
    public static SoilManager instance;
    public Tilemap Tilemap;

    public Dictionary<Vector3, SoilPlot> LandPlots;

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
        LandPlots = new Dictionary<Vector3, SoilPlot>();
        foreach(Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            if (!Tilemap.HasTile(localPlace)) continue;
            SoilPlot land = new SoilPlot
            {
                Sand = 0,
                Silt = 0,
                Clay = 0,

                LocalPlace = localPlace,
                WorldLocation = Tilemap.CellToWorld(localPlace),
                Tile = Tilemap.GetTile(localPlace),
                Name = localPlace.x + " , " + localPlace.y,
            };
            LandPlots.Add(land.WorldLocation, land);
        }
    }

}
