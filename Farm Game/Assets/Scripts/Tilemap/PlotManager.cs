using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlotManager : MonoBehaviour
{
    public static PlotManager instance;
    public Tilemap Tilemap;

    public Dictionary<Vector3, PlotBase> tiles;

    private void Awake()
    {
        //Constrains to allow for only one PlotManager
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GetPlotTiles();
    }

    //Instances all the plots
    private void GetPlotTiles()
    {
        tiles = new Dictionary<Vector3, PlotBase>();
        foreach (Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);

            if (!Tilemap.HasTile(localPlace)) continue;
            PlotBase tile = new PlotBase
            {
                LocalPlace = localPlace,
                WorldLocation = Tilemap.CellToWorld(localPlace),
                Tile = Tilemap.GetTile(localPlace),
                Tilemap = Tilemap,
                Name = localPlace.x + " , " + localPlace.y,
            };

            tiles.Add(tile.WorldLocation, tile);
        }
    }
}
