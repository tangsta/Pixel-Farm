using UnityEngine;

public class IOPlant : MonoBehaviour
{
    private Plant[,] PlantMap;
    public PlantTilemap CTilemap;

    public bool Plant(Vector3Int pos, Crop crop)
    {
        if (IsBound(pos.x, pos.y))
        {
            PlantMap[pos.x, pos.y] = new Plant(crop);
            CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);
            return true;
        }
        return false;
    }

    public Plant Harvest(Vector3Int pos)
    {
        Plant plant = GetPlant(pos);
        if (plant.State == GrowthState.Producing)
        {
            PlantMap[pos.x, pos.y] = null;
            CTilemap.Erase(pos);
            return plant;
        }
        return null;
    }

    public void GrowAll()
    {
        for (int x = 0; x < PlantMap.GetLength(0); x++)
            for (int y = 0; y < PlantMap.GetLength(1); y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (GetPlant(pos) != null && PlantMap[pos.x, pos.y].Grow())
                    CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);
            }
    }

    public void Grow(Vector3Int pos)
    {
        if (GetPlant(pos) != null && PlantMap[pos.x, pos.y].Grow())
            CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);
    }

    public void Water(Vector3Int pos)
    {
        if (GetPlant(pos) != null)
        {
            PlantMap[pos.x, pos.y].Water();
            CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);     
        }
    }

    public void DrawAll()
    {
        for (int x = 0; x < PlantMap.GetLength(0); x++)
            for (int y = 0; y < PlantMap.GetLength(1); y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (GetPlant(pos) != null)
                    CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);
            }         
    }

    public void Draw(Vector3Int pos)
    {
        CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);
    }

    public Plant GetPlant(Vector3Int pos)
    {
        if (IsBound(pos.x, pos.y) && PlantMap[pos.x, pos.y] != null)
            return PlantMap[pos.x, pos.y];
        return null;
    }

    private bool IsBound(int x, int y)
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
