using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropMap : MonoBehaviour
{
    public CropMap instance;
    public Tilemap Tilemap;
    public Dimensions dimension;

    public bool hasMap;

    public Crop[] Types;
    public Dictionary<Vector3, CropStats> Crops;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if (hasMap)
        {
            GetMap();
        }
    }

    private void GetMap()
    {
        Crops = new Dictionary<Vector3, CropStats>();

        foreach (Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            if (!Tilemap.HasTile(pos)) continue;
            Crops.Add(pos, GetCrop(pos));
        }
    }

    public CropStats GetCrop(Vector3Int pos)
    {
        TileBase check = Tilemap.GetTile(pos);
        int crop;
        int stage;

        for (crop = 0; crop < Types.Length; crop++)
        {
            for (stage = 0; stage < Types[crop].Stages.Length; stage++)
            {
                if (Types[crop].Stages[stage] == check) return new CropStats(Types[crop]);
            }
        }
        return new CropStats(Types[0]);
    }
}
