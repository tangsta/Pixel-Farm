using UnityEngine;

[CreateAssetMenu(fileName = "PlantTypes", menuName = "ScriptableObjects/PlantHandler", order = 1)]
public class PlantHandler : ScriptableObject
{
    [Header("Plant Type Definitions")]
    public PlantDef[] Type;
    
    public int GetID(PlantDef plant)
    {
        for (int i = 0; i < Type.Length; i++)
            if (Type[i] == plant)
                return i;
        return -1;
    }

    public PlantDef GetPlant(int id)
    {
        if (id >= 0 && id < Type.Length)
            return Type[id];
        return null;
    }
}
