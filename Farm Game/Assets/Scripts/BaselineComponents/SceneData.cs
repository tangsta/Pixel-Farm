using System.Collections.Generic;
using UnityEngine;

//Unites and globalizes values from Tilemaps
[CreateAssetMenu]
public class SceneData : ScriptableObject
{
    public Dimensions Dimensions;
    public Dictionary<Vector3Int, Land> Grounds;
    public Dictionary<Vector3Int, CropStats> Crops;
    //public Dictionary<Vector3, bool> Grasses;

}