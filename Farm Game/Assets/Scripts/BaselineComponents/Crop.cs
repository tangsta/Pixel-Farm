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
    //Minimum time you should wait for growth
    public int GrowthTime;
    //Minimum time you can water to progress next stage
    public int ThirstTime;
    //Random growth chance when conditions are met
    public float GrowthChance;
}
