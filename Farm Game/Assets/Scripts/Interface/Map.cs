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
        //LandMap.FillMap(0);
        GenerateMap();
        PlantMap.InitMap(Width, Height);

    }

    public bool CheckPlant(Vector3Int pos)
    {
        return PlantMap.IsPlant(pos.x, pos.y);
    }

    public bool Plant(Vector3Int pos, Crop crop)
    {
        return PlantMap.Plant(pos, crop);
    }

    public Plant Harvest(Vector3Int pos)
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
        return PlantMap.GetPlant(pos.x , pos.y);
    }

    public Land GetLand(Vector3Int pos)
    {
        return LandMap.GetLand(pos.x, pos.y);
    }

    public void GenerateMap()
    {
        LandMap.GenerateMap(0.335f, 0.455f, 12345, 54321, 0.5f, 50);
    }

    public void UpdateRenderAll()
    {
        LandMap.UpdateRenderAll();
        PlantMap.UpdateRenderAll();
    }

    public void UpdateRender(Vector3Int pos)
    {
        LandMap.UpdateRender(pos);
        PlantMap.UpdateRender(pos);
    }
}
