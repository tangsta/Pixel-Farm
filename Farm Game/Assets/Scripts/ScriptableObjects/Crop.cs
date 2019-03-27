using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Crop : ScriptableObject
{
    public Tile[] Stages;
    public AOE[] Specials;

    //Default Crop Values
    public int Produce;
    public float GrowthTime;
    public float WaterTime;
    public float GrowthChance;
}
