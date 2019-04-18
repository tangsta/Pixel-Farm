using UnityEngine;

public class IOPlant : MonoBehaviour
{
    private Plant[,] PlantMap;
    public CropTilemap CTilemap;

    public bool Plant(Vector3Int pos, Crop crop)
    {
        if (IsBound(pos.x, pos.y))
        {
            PlantMap[pos.x, pos.y] = new Plant(crop);
            CTilemap.Set(pos, crop, GrowthState.Seedling);
            return true;
        }
        return false;
    }

    public Plant Harvest(Vector3Int pos)
    {
        Plant plant = GetPlant(pos.x, pos.y);
        if (plant.State == GrowthState.Producing)
        {
            PlantMap[pos.x, pos.y] = null;
            CTilemap.Clear(pos);
            return plant;
        }
        return null;
    }

    public void GrowAll()
    {
        for (int x = 0; x < PlantMap.GetLength(0); x++)
            for (int y = 0; y < PlantMap.GetLength(1); y++)
                Grow(new Vector3Int(x, y, 0));
    }

    public void Grow(Vector3Int pos)
    {
        if (IsPlant(pos.x, pos.y))
        { 
            Plant plant = PlantMap[pos.x, pos.y];
            if (PlantMap[pos.x, pos.y].Grow())
                CTilemap.Set(pos, plant.Crop, plant.State);
        }
    }

    public void Water(Vector3Int pos)
    {
        if (IsPlant(pos.x, pos.y))
        {
            PlantMap[pos.x, pos.y].Water();
            Plant plant = PlantMap[pos.x, pos.y];
            CTilemap.Set(pos, plant.Crop, plant.State);
            
        }
    }

    public void UpdateRenderAll()
    {
        for (int x = 0; x < PlantMap.GetLength(0); x++)
            for (int y = 0; y < PlantMap.GetLength(1); y++)
                UpdateRender(new Vector3Int(x, y, 0));
    }

    public void UpdateRender(Vector3Int pos)
    {
        Plant plant = GetPlant(pos.x, pos.y);
        CTilemap.Set(pos, plant.Crop, plant.State);
    }

    public Plant GetPlant(int x, int y)
    {
        if (IsPlant(x, y))
            return PlantMap[x, y];
        return null;
    }

    public bool IsPlant(int x, int y)
    {
        if (IsBound(x, y) && PlantMap[x, y] != null)
            return true;
        return false;
    }

    public bool IsBound(int x, int y)
    {
        if (x >= 0 && x < PlantMap.GetLength(0) &&
            y >= 0 && y < PlantMap.GetLength(1))
            return true;
        return false;
    }

    public void InitMap(int width, int height)
    {
        PlantMap = new Plant[width, height];
    }
}
