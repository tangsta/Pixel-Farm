using UnityEngine;
using UnityEngine.Tilemaps;

public class MinigameTilemap : MonoBehaviour
{
    private Tilemap Tilemap;
    public Tile img;

    public void Awake()
    {
        Tilemap = GetComponent<Tilemap>();
    }

    public void Draw(Vector3Int pos)
    {
        Tilemap.SetTile(pos, img);
    }

    public void Erase(Vector3Int pos)
    {
        Tilemap.SetTile(pos, null);
    }
}
