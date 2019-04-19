/*  Last Edit:  [4/17/2019] - Donny
*  Reason:      Trying out a new method to prevent null exceptions
*               Unifying all the handlers into one class
* 
*  POTENTIAL CAPABILITIES ARE:
*      
*  CLASS PURPOSE:
*      To hold the DataMaps and have gateways to the Tilemap and data
*/
using UnityEngine;

public class Map : MonoBehaviour
{
    public int Height = 0;
    public int Width = 0;

    public IOLand LandMap;
    public IOPlant PlantMap;

    public void Start()
    {
        LandMap.InitMap(Width, Height);
        PlantMap.InitMap(Width, Height);
        GenerateMap();
    }

    public bool Plant(Vector3Int pos, int plant)
    {
        if (LandMap.GetLand(pos) != null)
            return PlantMap.Plant(pos, plant);
        return false;
    }

    public int Harvest(Vector3Int pos)
    {
        return PlantMap.Harvest(pos);
    }

    public void GrowAll()
    {
        PlantMap.GrowAll();
    }

    public void Grow(Vector3Int pos)
    {
        PlantMap.Grow(pos);
    }

    public void Water(Vector3Int pos)
    {
        PlantMap.Water(pos);
    }

    public Plant GetPlant(Vector3Int pos)
    {
        return PlantMap.GetPlant(pos);
    }

    public Land GetLand(Vector3Int pos)
    {
        return LandMap.GetLand(pos);
    }

    public void GenerateMap()
    {
        LandMap.GenerateMap(0.25f, 0.5);
    }

    public void DrawAll()
    {
        LandMap.DrawAll();
        PlantMap.DrawAll();
    }

    public void Draw(Vector3Int pos)
    {
        LandMap.Draw(pos);
        PlantMap.Draw(pos);
    }
}
