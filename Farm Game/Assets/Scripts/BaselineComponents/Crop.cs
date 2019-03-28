using UnityEngine;
using UnityEngine.Tilemaps;

//Baseline for definition of new crops
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
