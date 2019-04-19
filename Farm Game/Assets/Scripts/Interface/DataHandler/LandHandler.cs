using UnityEngine;

[CreateAssetMenu(fileName = "LandTypes", menuName = "ScriptableObjects/LandHandler", order = 2)]
public class LandHandler : ScriptableObject
{
    [Header("Land Type Definitions")]
    public LandDef[] Type;

    public int GetID(LandDef land)
    {
        for (int i = 0; i < Type.Length; i++)
            if (Type[i] == land)
                return i;
        return -1;
    }

    public LandDef GetLand(int id)
    {
        if (id >= 0 && id < Type.Length)
            return Type[id];
        return null;
    }
}
