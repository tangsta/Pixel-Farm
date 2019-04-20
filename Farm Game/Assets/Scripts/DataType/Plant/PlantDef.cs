using UnityEngine;

[CreateAssetMenu(menuName = "Plants/PlantDef", order = 1)]
public class PlantDef : ScriptableObject
{
    public PlantDNA DNA;
    public PlantArt Art;
    //public Effect[] Consumers;
    //public Effect[] Emitters;
    public Crop Crop;
}
