using UnityEngine;
using UnityEngine.Tilemaps;

public class Fog : MonoBehaviour
{
    public AnimatedTile[] FogState = new AnimatedTile[3];
    public Tilemap Map;
    public GroundHandler Grounds;
    public SceneData Scene;
    private int Height, Width;

    public void Awake()
    {
        Height = Scene.Dimensions.Height + 100;
        Width = Scene.Dimensions.Width + 100;
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                
                Vector3Int temp = new Vector3Int(x - 50, y - 50, 0);
                /*
                if (Grounds.GetGround(temp) == null)
                {
                */
                    Map.SetTile(temp, FogState[0]);
                //}
            }
        }
    }

    public void Try()
    {
        Vector3Int Check;
        foreach (Vector3Int pos in Scene.Grounds.Keys)
        {
            Check = pos + new Vector3Int(0, -1, 0);
            if (Scene.Grounds[pos] == null)
            {
                Debug.Log("CHECKING");
                Vector3Int Tile = new Vector3Int(Check.x - 50, Check.y - 50, 0);
                Map.SetTile(Tile, FogState[1]);
                Check = Check + new Vector3Int(0, -1, 0);
                if (Scene.Grounds[pos] == null)
                {
                    Tile = Tile + new Vector3Int(0, -1, 0);
                    Map.SetTile(Tile, FogState[2]);
                }
            }
        }
    }
}
