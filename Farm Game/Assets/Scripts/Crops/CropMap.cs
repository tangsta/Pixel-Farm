using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropMap : MonoBehaviour
{
    private CropMap instance;

    public Tilemap Tilemap;
    public Dimensions dimension;
    public SceneData scene;

    public bool hasMap;

    public Crop[] Types;
    public Dictionary<Vector3Int, CropStats> Crops;

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
        Crops = new Dictionary<Vector3Int, CropStats>();

        if (hasMap)
        {
            GetMap();
        }
    }

    public void GrowAll()
    {
        foreach (Vector3Int pos in Crops.Keys)
        {
            Crops[pos].Grow();
        }
        updateDicts();
    }

    private void GetMap()
    {
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

    public void updateDicts()
    {
        scene.Crops = Crops;
    }

    public void SpawnCrop(Vector3 pos, Crop crop)
    {
        Vector3Int point = new Vector3Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), 0);
        if (Crops.ContainsKey(point))
        {
            Debug.Log("There is already a plant here");
        }
        else
        {
            Crops.Add(point, new CropStats(crop));
            Tilemap.SetTile(new Vector3Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), 0), crop.Stages[0]);
        }
    }

    public void DeleteCrop(Vector3 pos)
    {
        Vector3Int point = new Vector3Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), 0);
        Crops.Remove(point);
        Tilemap.SetTile(point, null);
    }

    //for the soil layer only for now
    public void TriggerCropEffects()
    {
        foreach (Vector3Int pos in Crops.Keys)
        {
            Crops[pos].TriggerSpecials();
        }
    }
     
    public void AOEProduce (Vector3Int pos, int range, float multiplier)
    {
        for (int x = pos.x - range; x < pos.x + range; x++)
        {
            for (int y = pos.y - range; y < pos.y + range; y++)
            {
                if (Tilemap.GetTile(new Vector3Int(x, y, 0)) != null)
                {
                    Crops[pos].Produce = Mathf.FloorToInt(Crops[pos].Produce * multiplier);
                }
            }
        }
    }

    public void AOEGrowth (Vector3Int pos, int range, float increment)
    {
        for (int x = pos.x - range; x < pos.x + range; x++)
        {
            for (int y = pos.y - range; y < pos.y + range; y++)
            {
                if (Tilemap.GetTile(new Vector3Int(x, y, 0)) != null)
                {
                    if (Crops[pos].GrowthChance + increment > 1)
                    {
                        Crops[pos].GrowthChance = 0.99f;
                    }
                    else if (Crops[pos].GrowthChance + increment < 0)
                    {
                        Crops[pos].GrowthChance = 0.01f;
                    }
                }
            }
        }
    }
}
