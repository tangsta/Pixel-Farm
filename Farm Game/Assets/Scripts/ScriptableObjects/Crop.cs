using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Crop : ScriptableObject
{
    public Tile[] Stages;
    public int Produce;
    public int Range;
    public float GrowthTime;
    public float WaterTime;
    public float GrowthChance;
    public AOE[] Specials;
}
