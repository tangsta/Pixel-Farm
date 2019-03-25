using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Crop : ScriptableObject
{
    public Tile[] Stages;
    public int Produce;
    public float GrowthTime;
    public float WaterTime;
    public float GrowthChance;
}
