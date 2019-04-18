
/*  Last Edit:  [3/28/2019] - Donny
*  Reason:     Seperates functionality from Tilemap into a Tilemap Handler
* 
*  POTENTIAL CAPABILITIES ARE:
*      Shade Tiles in a color
*      Refresh Tiles (Connected textures implementation)
*      Swap Tiles with a new Tile
*      
*  CLASS PURPOSE:
*      An interface to update tilemap
*/
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

[AddComponentMenu("Tilemap/Ground Tilemap")]
public class GroundTilemap : MonoBehaviour
{
    public Tile[] Type = new Tile[4];
    public AnimatedTile[] Fog = new AnimatedTile[3];
    private Tilemap Map;

    public void Awake()
    {
        Map = GetComponent<Tilemap>();
    }

    public void Set(Vector3Int pos, byte? type)
    {
        if (type == null)
        {
            Vector3Int check = pos + Vector3Int.up;
            if (IsSurface(check))
            {
                Map.SetTile(pos, Fog[0]);
                check += (Vector3Int.down * 2);
                if (!IsSurface(check))
                {
                    pos += Vector3Int.down;
                    Map.SetTile(pos, Fog[1]);
                    check += Vector3Int.down;
                    if (!IsSurface(check))
                    {
                        pos += Vector3Int.down;
                        Map.SetTile(pos, Fog[2]);
                    }
                }
            }
        }
        else
        {
            Map.SetTile(pos, Type[type ?? default]);
        }
    }

    public void RenderFog(int width, int height)
    {
        for (int x = -20; x < width + 20; x++)
            for (int y = -20; y < height + 20; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                Vector3Int check = pos + Vector3Int.up;
                if (IsSurface(check) && !IsSurface(pos))
                {
                    Map.SetTile(pos, Fog[0]);
                    check += (Vector3Int.down * 2);
                    if (!IsSurface(check))
                    {
                        pos += Vector3Int.down;
                        Map.SetTile(pos, Fog[1]);
                        check += Vector3Int.down;
                        if (!IsSurface(check))
                        {
                            pos += Vector3Int.down;
                            Map.SetTile(pos, Fog[2]);
                        }
                    }
                }
            }
    }

    public void InitMap(int width, int height)
    {
        for (int x = -20; x < width + 20; x++)
            for (int y = -20; y < height + 20; y++)
                Map.SetTile(new Vector3Int(x, y, 0), Fog[2]);
    }

    private bool IsSurface(Vector3Int pos)
    {
        foreach (Tile tile in Type)
            if (Map.GetTile(pos) == tile)
                return true;
        return false;
    }
}
