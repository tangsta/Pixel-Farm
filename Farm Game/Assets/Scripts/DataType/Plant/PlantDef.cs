using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Plants/Plant", order = 1)]
public class PlantDef : ScriptableObject
{
    public Tile[] Stage;
    //public Effect[] Consumers;
    //public Effect[] Emitters;
    public int Produce;
    public PlantAlter Alter;
    public PlantTime Time;
    public float GrowthChance;
}
