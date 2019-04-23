using UnityEngine;

[CreateAssetMenu(fileName = "MinigameHandler", menuName = "ScriptableObjects/MinigameHandler")]
public class MinigameHandler : ScriptableObject
{
    public Minigame[] Type;

    public int GetID(Minigame x)
    {
        for (int i = 0; i < Type.Length; i++)
            if (Type[i] == x)
                return i;
        return -1;
    }

    public Minigame GetGame(int id)
    {
        if (id >= 0 && id < Type.Length)
            return Type[id];
        return null;
    }
}
