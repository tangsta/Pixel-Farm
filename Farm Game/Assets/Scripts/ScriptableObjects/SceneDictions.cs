using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneDictions : ScriptableObject
{
    //public Dimensions dimension;
    public Dictionary<Vector3, GroundStats> Grounds;
    public Dictionary<Vector3, CropStats> Crops;
    //public Dictionary<Vector3, bool> Grasses;

}