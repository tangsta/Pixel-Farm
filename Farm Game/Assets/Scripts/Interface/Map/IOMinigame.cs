using System.Collections.Generic;
using UnityEngine;

public class IOMinigame : MonoBehaviour
{
    private Dictionary<Vector3Int, Minigame> GameMap;
    public MinigameHandler Minigames;
    public MinigameTilemap Map;

    public int NumGames;
    public int Range;

    public void Awake()
    {
        GameMap = new Dictionary<Vector3Int, Minigame>();
    }

    public int Play(Vector3Int pos)
    {
        if (GameMap.ContainsKey(pos))
        {
            return GameMap[pos].Play();
        }
        return -1;
    }

    public void SpawnGame(Vector3Int pos)
    {
        if (NumGames > 0 && !GameMap.ContainsKey(pos))
        {
            GameMap.Add(pos, Minigames.GetGame(Random.Range(0, Minigames.Type.Length)));
            Map.Draw(pos);
            NumGames--;
        }
    }

    public void DespawnGame(float chance)
    {
        if (Random.value > chance)
        {
            Vector3Int[] Arr = new Vector3Int[GameMap.Count];
            int i = 0;

            foreach (Vector3Int x in GameMap.Keys)
            {
                Arr[i] = x;
                i++;
            }

            Vector3Int pos = Arr[Random.Range(0, Arr.Length-1)];
            GameMap.Remove(pos);
            Map.Erase(pos);
            NumGames++;
        }
    }

}
