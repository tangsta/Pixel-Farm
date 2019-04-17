<<<<<<< HEAD:Farm Game/Assets/Scripts/BaselineComponents/SceneData.cs
﻿using System.Collections.Generic;
using UnityEngine;

//Unites and globalizes values from Tilemaps
[CreateAssetMenu]
public class SceneData : ScriptableObject
{
    public Dimensions Dimensions;
    public Dictionary<Vector3Int, Land> Grounds;
    public Dictionary<Vector3Int, CropStats> Crops;
    //public Dictionary<Vector3, bool> Grasses;

=======
﻿using System.Collections.Generic;
using UnityEngine;

//Unites and globalizes values from Tilemaps
[CreateAssetMenu]
public class SceneData : ScriptableObject
{
    public Dimensions Dimensions;
    public Dictionary<Vector3Int, GroundStats> Grounds;
    public Dictionary<Vector3Int, CropStats> Crops;
    //public Dictionary<Vector3, bool> Grasses;

>>>>>>> PlantLayer:Farm Game/Assets/Scripts/Donny/BaselineComponents/SceneData.cs
}