using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneData : ScriptableObject
{
    public Dictionary<Vector3Int, GroundStats> Grounds;
    public Dictionary<Vector3Int, CropStats> Crops;
    //public Dictionary<Vector3, bool> Grasses;

}