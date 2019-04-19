using UnityEngine;

[CreateAssetMenu(menuName = "Plants/Alter", order = 3)]
public class PlantAlter : ScriptableObject
{
    [Header("Plant Alter Manipulators")]
    public float ProDec;
    public float ProInc;
    public float GroDec;
    public float GroInc;
}
