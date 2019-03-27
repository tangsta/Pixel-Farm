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
            Debug.Log("getmap");
        }
        else
        {
            SetMap();
        }
    }

    public void GrowAll()
    {
        foreach (Vector3Int pos in Crops.Keys)
        {
            if (Crops[pos] != null)
            {
                Crops[pos].Grow();
                Tilemap.SetTile(pos, Crops[pos].Crop.Stages[(int)Crops[pos].State]);
            }
        }
        updateDicts();
    }

    private void SetMap()
    {
        for (int x = 0; x < dimension.Width; x++)
        {
            for (int y = 0; y < dimension.Height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                Crops.Add(pos, null);
            }
        }
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

    public bool SpawnCrop(Vector3 pos, Crop crop)
    {
        Vector3Int point = new Vector3Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), 0);
        if (Crops.ContainsKey(point) && Crops[point] == null)
        {
            Crops[point] =  new CropStats(crop);
            Tilemap.SetTile(new Vector3Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), 0), crop.Stages[0]);
            return true;
        }
        else
        {
            //Tell user that it is an invalid action
            Debug.Log("Cant plant here BRO");
            return false;
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
            if (Crops[pos] != null)
            {
                Crops[pos].TriggerSpecials();
            }
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
