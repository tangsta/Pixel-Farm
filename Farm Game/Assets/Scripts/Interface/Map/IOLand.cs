using UnityEngine;

public class IOLand : MonoBehaviour
{
    private Land[,] LandMap;
    public LandTilemap GTilemap;

    public void DrawAll()
    {
        for (int x = 0; x < LandMap.GetLength(0); x++)
            for (int y = 0; y < LandMap.GetLength(1); y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                GTilemap.Draw(pos, LandMap[pos.x, pos.y]);
            }
        GTilemap.DrawFog(LandMap.GetLength(0), LandMap.GetLength(1));
    }

    public void Draw(Vector3Int pos)
    {
        GTilemap.Draw(pos, LandMap[pos.x, pos.y]);
    }

    public void Draw(Vector3Int pos, Land land)
    {
        GTilemap.Draw(pos, land);
    }

    public int GetGrain(Vector3Int pos)
    {
        if (GetLand(pos) != null)
            return LandMap[pos.x, pos.y].MesGrain();
        return -1;
    }

    public int GetOrg(Vector3Int pos)
    {
        if (GetLand(pos) != null)
            return LandMap[pos.x, pos.y].MesOrg();
        return -1;
    }

    public int GetMoist(Vector3Int pos)
    {
        if (GetLand(pos) != null)
            return LandMap[pos.x, pos.y].MesMoist();
        return -1;
    }

    public void GenerateMap(float Variance, double density)
    {
        density = 1 - density;
        for (int x = 0; x < LandMap.GetLength(0); x++)
            for (int y = 0; y < LandMap.GetLength(1); y++)
            {
                float xCord = x * 0.335f + 12345;
                float yCord = y * 0.335f + 54321;
                float val = Mathf.PerlinNoise(xCord, yCord);

                if (val > density)
                {
                    int Grain = (int) Random.Range(5, Variance * 4096);
                    int Organic = (int) Random.Range(0, Variance * 100);
                    int Moisture = (int) Random.Range(0, Variance * 100);

                    LandMap[x, y] = new Land(Grain, Organic, Moisture);
                }
            }
        DrawAll();
    }

    public void AddGrain(Vector3Int pos, int radius, int val)
    {
        for (int xPos = pos.x - radius; xPos < pos.x + radius; xPos++)
            for (int yPos = pos.y - radius; yPos < pos.y + radius; yPos++)
                if (GetLand(new Vector3Int(xPos, yPos, 0)) != null)
                    LandMap[xPos, yPos].AddGrain(val);
    }

    public void AddGrain(Vector3Int pos, int val)
    {
        if(GetLand(pos) != null)
            LandMap[pos.x, pos.y].AddGrain(val);
    }

    public void AddOrg(Vector3Int pos, int radius, int val)
    {
        for (int xPos = pos.x - radius; xPos < pos.x + radius; xPos++)
            for (int yPos = pos.y - radius; yPos < pos.y + radius; yPos++)
                if (GetLand(new Vector3Int(xPos, yPos, 0)) != null)
                    LandMap[xPos, yPos].AddOrg(val);
    }

    public void AddOrg(Vector3Int pos, int val)
    {
        if (GetLand(pos) != null)
            LandMap[pos.x, pos.y].AddOrg(val);
    }

    public void AddMoist(Vector3Int pos, int radius, int val)
    {
        for (int xPos = pos.x - radius; xPos < pos.x + radius; xPos++)
            for (int yPos = pos.y - radius; yPos < pos.y + radius; yPos++)
                if (GetLand(new Vector3Int(xPos, yPos, 0)) != null)
                    LandMap[xPos, yPos].AddMoist(val);
    }

    public void AddMoist(Vector3Int pos, int val)
    {
        if (GetLand(pos) != null)
            LandMap[pos.x, pos.y].AddMoist(val);
    }

    public Land GetLand(Vector3Int pos)
    {
        if (IsBound(pos.x, pos.y) && LandMap[pos.x, pos.y] != null)
            return LandMap[pos.x, pos.y];
        return null;
    }

    private bool IsBound(int x, int y)
    {
        if (x >= 0 && x < LandMap.GetLength(0) &&
            y >= 0 && y > LandMap.GetLength(1))
            return true;
        return false;
    }

    public void InitMap(int width, int height)
    {
        GTilemap.InitMap(width, height);
        LandMap = new Land[width, height];
    }

    //Needs a new Land constructor to create specific types
    public void FillMap(byte type)
    {
        for (int x = 0; x < LandMap.GetLength(0); x++)
            for (int y = 0; y < LandMap.GetLength(1); y++)
            {
                //LandMap[x, y] = new Land(type)
                Draw(new Vector3Int(x, y, 0));
            }
        GTilemap.DrawFog(LandMap.GetLength(0), LandMap.GetLength(1)); 
    }
}
