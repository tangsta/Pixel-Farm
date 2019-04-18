using UnityEngine;

public class IOLand : MonoBehaviour
{
    private Land[,] LandMap;
    public GroundTilemap GTilemap;

    public void UpdateRenderAll()
    {
        for (int x = 0; x < LandMap.GetLength(0); x++)
            for (int y = 0; y < LandMap.GetLength(1); y++)
                UpdateRender(new Vector3Int(x, y, 0));
    }

    public void UpdateRender(Vector3Int pos)
    {
        GTilemap.Set(pos, LandMap[pos.x, pos.y].UpdateState());
    }

    public int GetGrain(int x, int y)
    {
        if (IsLand(x, y))
            return LandMap[x, y].MesGrain();
        return -1;
    }

    public int GetOrganic(int x, int y)
    {
        if (IsLand(x, y))
            return LandMap[x, y].MesOrganic();
        return -1;
    }

    public int GetMoisture(int x, int y)
    {
        if (IsLand(x, y))
            return LandMap[x, y].MesMoisture();
        return -1;
    }

    public Land GetLand(int x, int y)
    {
        if (IsLand(x, y))
            return LandMap[x, y];
        return null;
    }

    public void GenerateMap(float xFreq, float yFreq, float xOffset, float yOffset,
                            float Variance, float Amp)
    {
        for (int x = 0; x < LandMap.GetLength(0); x++)
            for (int y = 0; y < LandMap.GetLength(1); y++)
            {
                float xCord = x * xFreq + xOffset;
                float yCord = y * yFreq + yOffset;
                float val = Mathf.PerlinNoise(xCord, yCord) * Amp;

                if (val > 20)
                {
                    int Grain = (int) Random.Range(5, Variance * 4096);
                    int Organic = (int) Random.Range(0, Variance * 100);
                    int Moisture = (int) Random.Range(0, Variance * 100);

                    LandMap[x, y] = new Land(Grain, Organic, Moisture);
                    Debug.Log(LandMap[x, y].UpdateState());

                    UpdateRender(new Vector3Int(x, y, 0));
                }
            }
        GTilemap.RenderFog(LandMap.GetLength(0), LandMap.GetLength(1));
    }

    public void GrainEffect(int x, int y, int radius, int val)
    {
        for (int xPos = x - radius; xPos < x + radius; xPos++)
            for (int yPos = y - radius; yPos < y + radius; yPos++)
                if (IsLand(xPos, yPos))
                    LandMap[xPos, yPos].GrainAdd(val);
    }

    public void OrganicEffect(int x, int y, int radius, int val)
    {
        for (int xPos = x - radius; xPos < x + radius; xPos++)
            for (int yPos = y - radius; yPos < y + radius; yPos++)
                if (IsLand(xPos, yPos))
                    LandMap[xPos, yPos].OrganicAdd(val);
    }

    public void MoistureEffect(int x, int y, int radius, int val)
    {
        for (int xPos = x - radius; xPos < x + radius; xPos++)
            for (int yPos = y - radius; yPos < y + radius; yPos++)
                if (IsLand(xPos, yPos))
                    LandMap[xPos, yPos].MoistureAdd(val);
    }

    public bool IsLand(int x, int y)
    {
        if (IsBound(x, y) && LandMap[x, y].UpdateState() != 0)
            return true;
        return false;
    }

    public bool IsBound(int x, int y)
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

    public void FillMap(byte type)
    {
        for (int x = 0; x < LandMap.GetLength(0); x++)
            for (int y = 0; y < LandMap.GetLength(1); y++)
            {
                //LandMap[x, y] = new Land(type)
                GTilemap.Set(new Vector3Int(x, y, 0), type);
            }
        GTilemap.RenderFog(LandMap.GetLength(0), LandMap.GetLength(1));
        
    }
}
