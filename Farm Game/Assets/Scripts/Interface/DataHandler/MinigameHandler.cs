using UnityEngine;

[CreateAssetMenu(fileName = "MinigameHandler", menuName = "ScriptableObjects/MinigameHandler")]
public class MinigameHandler : ScriptableObject
{
    public MiniGame[] Type;

    public int GetID(MiniGame x)
    {
        for (int i = 0; i < Type.Length; i++)
            if (Type[i] == x)
                return i;
        return -1;
    }

    public MiniGame GetGame(int id)
    {
        if (id >= 0 && id < Type.Length)
            return Type[id];
        return null;
    }
}
