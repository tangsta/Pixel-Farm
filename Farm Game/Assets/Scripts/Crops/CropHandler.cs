/*  Last Edit:  [3/28/2019] - Donny
 *  Reason:     Seperates functionality from Tilemap into a Dictionary Handler
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *    
 *      
 *  CLASS PURPOSE:
 *      An interface to manipulate crops for other classes while updating tilemap
 */
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Managers/Crop Handler")]
public class CropHandler : MonoBehaviour
{   
    private CropTilemap Field;

    public bool Load;       //Build Dictionary from saved values

    public SceneData Scene;
    public Dictionary<Vector3Int, CropStats> Crops;

    //Initializes Dictionary and its bounds
    public void Awake()
    {
        Field = GetComponentInChildren<CropTilemap>();

        if (Load)
        {
            //Load functionality
        }
        else
        {
            Scene.Crops = new Dictionary<Vector3Int, CropStats>();
            for (int x = 0; x < Scene.Dimensions.Width; x++)
            {
                for (int y = 0; y < Scene.Dimensions.Height; y++)
                {
                    Vector3Int point = new Vector3Int(x, y, 0);
                    Scene.Crops.Add(point, null);
                }
            }
        }
    }

    public bool Plant(Vector3Int pos, Crop crop)
    {
        if (Scene.Crops.ContainsKey(pos) && Scene.Crops[pos] == null)
        {
            Scene.Crops[pos] = new CropStats(crop);
            Field.Replace(pos, crop, GrowthState.Seedling);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlantAll(Crop crop)
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            Plant(pos, crop);
        }
    }

    public CropStats HarvestCrop(Vector3Int pos)
    {
        CropStats crop = Scene.Crops[pos];
        if (crop.State == GrowthState.Producing)
        {
            Scene.Crops[pos] = null;
            Field.Clear(pos);
            return crop;
        }
        return null;
    }

    public CropStats HarvestAllCrop(Crop crop)
    {
        CropStats output = new CropStats(crop);
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            if (Scene.Crops[pos].Crop == crop)
            {
                //Sum up all into one crop 
                //output += HarvestCrop(pos);
                Clear(pos);
            }
        }
        return output;
    }

    public void TriggerCrop(Vector3Int pos)
    {
        if (Scene.Crops.ContainsKey(pos))
        {
            Scene.Crops[pos].Trigger();
        }
    }

    public void TriggerAllCrop(Crop crop)
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            if (Scene.Crops[pos].Crop == crop)
            {
                TriggerCrop(pos);
            }
        }
    }

    public void TriggerAllCrop()
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            TriggerCrop(pos);
        }
    }

    public void Grow(Vector3Int pos)
    {
        if (Scene.Crops.ContainsKey(pos) && Scene.Crops[pos].Grow())
        {
            Field.Replace(pos, Scene.Crops[pos].Crop, Scene.Crops[pos].State);
        }
    }

    public void GrowAll(Crop crop)
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            if (Scene.Crops[pos].Crop == crop)
            {
                Grow(pos);
            }
        }
    }

    public void GrowAll()
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            Grow(pos);
        }
    }

    public void Water(Vector3Int pos)
    {
        if (Scene.Crops.ContainsKey(pos) && Scene.Crops[pos].Water())
        {
            Field.Replace(pos, Scene.Crops[pos].Crop, Scene.Crops[pos].State);
        }
    }
    
    public void WaterAll(Crop crop)
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            if (Scene.Crops[pos].Crop == crop)
            {
                Water(pos);
            }
        }
    }

    public void WaterAll()
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            Water(pos);
        }
    }

    public void Clear(Vector3Int pos)
    {
        if (Scene.Crops.ContainsKey(pos))
        {
            Scene.Crops[pos] = null;
            Field.Clear(pos);
        }
    }

    public void ClearAll(Crop crop)
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            if (Scene.Crops[pos].Crop == crop)
            {
                Clear(pos);
            }
        }
    }

    public void ClearAll()
    {
        foreach (Vector3Int pos in Scene.Crops.Keys)
        {
            Clear(pos);
        }
    }

    public CropStats GetCrop(Vector3Int pos)
    {
        if (Scene.Crops.ContainsKey(pos))
        {
            return Scene.Crops[pos];
        }
        return null;
    }
}
