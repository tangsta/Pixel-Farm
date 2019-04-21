using UnityEngine;

public class IOPlant : MonoBehaviour
{
    private Plant[,] PlantMap;
    public PlantTilemap CTilemap;
    public PlantHandler PlantID;

    public bool Plant(Vector3Int pos, int type)
    {
        if (IsBound(pos.x, pos.y))
        {
            PlantMap[pos.x, pos.y] = new Plant(PlantID.GetPlant(type));
            CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);
            return true;
        }
        return false;
    }

    public int Harvest(Vector3Int pos)
    {
        Plant plant = GetPlant(pos);
        if (plant != null && plant.Harvest() != -1)
        {
            PlantMap[pos.x, pos.y] = null;
            CTilemap.Erase(pos);
            return plant.Harvest();
        }
        else
            return -1;
    }

    public void AgeAll()
    {
        for (int x = 0; x < PlantMap.GetLength(0); x++)
            for (int y = 0; y < PlantMap.GetLength(1); y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (GetPlant(pos) != null)
                {
                    PlantMap[pos.x, pos.y].Age(1);
                    CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);
                }
            }
    }

    public void Age(Vector3Int pos)
    {
        if (GetPlant(pos) != null)
        {
            PlantMap[pos.x, pos.y].Age(1);
            CTilemap.Draw(pos, PlantMap[pos.x, pos.y]);
        }
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
