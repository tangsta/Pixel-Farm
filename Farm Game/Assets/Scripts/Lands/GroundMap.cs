using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundMap : MonoBehaviour
{
    public GroundMap instance;
    public Tilemap Tilemap;
    public Tile[] Tiles = new Tile[8];
    public Dimensions dimension;
    public SceneDictions dicts;

    public bool hasMap;

    //Procedural variables
    public byte Variance;
    public float xFreq;             //Varies x
    public float yFreq;             //Varies y
    public float xOffset;           //Noise Pos of x
    public float yOffset;           //Noise Pos of y
    public float Amp;               //Amplitude of noise
    public float SandOffset;        //Noise Pos for Sand
    public float SiltOffset;        //Noise Pos for Silt
    public float ClayOffset;        //Noise Pos for Clay

    public Dictionary<Vector3, GroundStats> Grounds;

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
        else
        {
            SetMap();
        }
    }

    public void SetMap()
    {
        Grounds = new Dictionary<Vector3, GroundStats>();

        for (int x = 0; x < dimension.Width; x++)
        {
            for (int y = 0; y < dimension.Height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                float xCord = x * xFreq + xOffset;
                float yCord = y * yFreq + yOffset;

                byte sample = (byte)Random.Range(-Variance, Variance);
                byte sand = (byte)((Mathf.PerlinNoise(xCord + SandOffset, yCord + SandOffset) * Amp));
                if (sample > 0 && sample < sand)
                {
                    sand += sample;
                }
                else if (sample < 0 && Mathf.Abs(sample) < sand)
                {
                    sand -= sample;
                }

                sample = (byte)Random.Range(-Variance, Variance);
                byte silt = (byte)((Mathf.PerlinNoise(xCord + SiltOffset, yCord + SiltOffset) * Amp));
                if (sample > 0 && sample < silt)
                {
                    silt += sample;
                }
                else if (sample < 0 && Mathf.Abs(sample) < silt)
                {
                    silt -= sample;
                }

                sample = (byte)Random.Range(-Variance, Variance);
                byte clay = (byte)((Mathf.PerlinNoise(xCord + ClayOffset, yCord + ClayOffset) * Amp));
                if (sample > 0 && sample < clay)
                {
                    clay += sample;
                }
                else if (sample < 0 && Mathf.Abs(sample) < clay)
                {
                    clay -= sample;
                }

                GroundStats ground = new GroundStats(sand, silt, clay);

                Grounds.Add(pos, ground);
                Tilemap.SetTile(pos, Tiles[(int)ground.Type]);
            }
        }
    }

    public void GetMap()
    {
        Grounds = new Dictionary<Vector3, GroundStats>();
        
        foreach (Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            if (!Tilemap.HasTile(pos)) continue;
            Grounds.Add(pos, GetGround(pos));
        }
    }

    public GroundStats GetGround(Vector3Int pos)
    {
        TileBase check = Tilemap.GetTile(pos);
        int Type;

        for (Type = 0; Type < Tiles.Length; Type++)
        {
            if (Tiles[Type] == check) break;
        }

        switch(Type)
        {
            case 0:     return new GroundStats(0, 0, 0);      
            case 1:     return new GroundStats(113, 6, 6);   
            case 2:     return new GroundStats(10, 100, 15); 
            case 3:     return new GroundStats(34, 40, 50);   
            case 4:     return new GroundStats(75, 25, 25);  
            case 5:     return new GroundStats(25, 75, 25);   
            case 6:     return new GroundStats(75, 40, 10);   
            case 7:     return new GroundStats(100, 100, 100);
            default:
                Debug.Log("GroundStats creation error: Does not exist");
                return new GroundStats();
        } 
    }

    public void updateDicts()
    {
        dicts.Grounds = Grounds;
    }
}
