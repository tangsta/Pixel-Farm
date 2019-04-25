using UnityEngine;
using UnityEngine.Tilemaps;

public class MinigameTilemap : MonoBehaviour
{
    private Tilemap Map;
    public Tile Img;

    public void Awake()
    {
        Map = GetComponent<Tilemap>();
    }

    public void Draw(Vector3Int pos)
    {
        Map.SetTile(pos, Img);
    }

    public void Erase(Vector3Int pos)
    {
        Map.SetTile(pos, null);
    }
}
