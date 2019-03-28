/*  Last Edit:  [3/28/2019] - Donny
 *  Reason:     Seperates functionality from Tilemap into a Dictionary Handler
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *      Calling a Generate function from other classes 
 *      Rework generation for better patterns in game
 *      
 *  CLASS PURPOSE:
 *      An interface to manipulate grounds for other classes while updating tilemap
 */
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Managers/Ground Handler")]
public class GroundHandler : MonoBehaviour
{
    private GroundTilemap Field;

    public bool Generate;   //Generate a noise based Dictionary
    public bool Load;       //Build Dictionary from saved values

    public SceneData Scene;
    public Dictionary<Vector3Int, GroundStats> Grounds;

    public float xFreq, xOffset;
    public float yFreq, yOffset;
    public float Variance;
    public float Amp;
    public float ClayOffset;
    public float SiltOffset;
    public float SandOffset;

    //Initializes Dictionary and its bounds
    public void Awake()
    {
        Field = GetComponentInChildren<GroundTilemap>();

        if (Load)
        {

        }
        else if (Generate)
        {
            Scene.Grounds = new Dictionary<Vector3Int, GroundStats>();
            for (int x = 0; x < Scene.Dimensions.Width; x++)
            {
                for (int y = 0; y < Scene.Dimensions.Height; y++)
                {
                    Vector3Int point = new Vector3Int(x, y, 0);

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

                    Scene.Grounds.Add(point, new GroundStats(sand, silt, clay));
                    Field.Replace(point, Scene.Grounds[point].Type);
                }
            }
        }
        else
        {
            Scene.Grounds = new Dictionary<Vector3Int, GroundStats>();
            for (int x = 0; x < Scene.Dimensions.Width; x++)
            {
                for (int y = 0; y < Scene.Dimensions.Height; y++)
                {
                    Vector3Int point = new Vector3Int(x, y, 0);
                    Scene.Grounds.Add(point, new GroundStats(0, 0, 0));
                    //Send Tilemap update
                }
            }
        }
    }

    public void TypeUpdate(Vector3Int pos)
    {
        if (Scene.Grounds.ContainsKey(pos))
        {
            Scene.Grounds[pos].UpdateType();
            Field.Replace(pos, Scene.Grounds[pos].Type);
        }
    }

    public void TypeUpdateAll()
    {
        foreach (Vector3Int pos in Scene.Grounds.Keys)
        {
            TypeUpdate(pos);
        }
    }

    public void GroundUpdate(Vector3Int pos, byte sand, byte silt, byte clay)
    {
        if (Scene.Grounds.ContainsKey(pos))
        {
            Scene.Grounds[pos] = new GroundStats(sand, silt, clay);
            Field.Replace(pos, Scene.Grounds[pos].Type);
        }
    }

    public void GroundUpdateAll(byte sand, byte silt, byte clay)
    {
        foreach (Vector3Int pos in Scene.Grounds.Keys)
        {
            GroundUpdate(pos, sand, silt, clay);
        }
    }

    public void GroundDefault(Vector3Int pos)
    {
        if (Scene.Grounds.ContainsKey(pos))
        {
            Scene.Grounds[pos] = new GroundStats();
            Field.Replace(pos, Scene.Grounds[pos].Type);
        }
    }

    public void GroundDefaultAll()
    {
        foreach (Vector3Int pos in Scene.Grounds.Keys)
        {
            GroundDefault(pos);
        }
    }

    public GroundStats GetGround(Vector3Int pos)
    {
        if (Scene.Grounds.ContainsKey(pos))
        {
            return Scene.Grounds[pos];
        }
        return null;
    }

    /*
     * Default definitions just in case needed
     * 
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
     */
}
