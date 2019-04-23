using System.Collections.Generic;
using UnityEngine;

public class IOMinigames : MonoBehaviour
{
    private Dictionary<Vector3Int, MiniGame> GameMap;
    public MinigameHandler Minigames;
    public MinigameTilemap Map;

    public int NumGames;
    public int Range;

    public void Awake()
    {
        GameMap = new Dictionary<Vector3Int, MiniGame>();
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
        if (NumGames > 0)
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
            foreach (Vector3Int pos in GameMap.Keys)
            {
                GameMap.Remove(pos);
                Map.Erase(pos);
                NumGames++;
                break;
            }
        }
    }

}
