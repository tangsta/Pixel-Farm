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

    public ContentManager content;
    public Dictionary<Vector3Int, CropStats> Crops;

    //Preinitialize
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

    //Forces each plant to attempt to grow
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

    //Sets map based on dimensions given
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

    //Reads the current Tilemap to create Map
    private void GetMap()
    {
        foreach (Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            if (!Tilemap.HasTile(pos)) continue;
            Crops.Add(pos, GetCrop(pos));
        }
    }

    //helper for GetMap()
    private CropStats GetCrop(Vector3Int pos)
    {
        TileBase check = Tilemap.GetTile(pos);

        foreach (Definition def in content.ContentDiction.Values)
        {
            for (int i = 0; i < def.Crop.Stages.Length; i++)
            {
                if (def.Crop.Stages[i] == check) return new CropStats(def.Crop);
            }
        }
        return null;
    }

    //Updates global dictionaries
    public void updateDicts()
    {
        scene.Crops = Crops;
    }

    //Plant crop while checking availablity 
    public bool PlantCrop(Vector3 pos, int ID)
    {
        Vector3Int point = new Vector3Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), 0);
        if (Crops.ContainsKey(point) && Crops[point] == null)
        {
            Crop crop = ((Definition)content.ContentDiction[ID]).Crop;
            Crops[point] = new CropStats(crop);
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

    //Removes full grown plants and gives its stats before being deleted
    public CropStats HarvestCrop(Vector3 pos)
    {
        Vector3Int point = new Vector3Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), 0);
        CropStats output = Crops[point];
        Crops[point] = null;
        Tilemap.SetTile(point, null);
        return output;
    }

    //Preemptive AOE functionality 
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
     
    //Preemptive AOE helpers 
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
