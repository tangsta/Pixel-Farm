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
using UnityEngine;
using UnityEngine.Tilemaps;

[AddComponentMenu("Tilemap/Ground Tilemap")]
public class GroundTilemap : MonoBehaviour
{
    public Tile[] Type = new Tile[8];
    private Tilemap Tilemap;

    public void Awake()
    {
        Tilemap = GetComponent<Tilemap>();
    }

    public void Replace(Vector3Int pos, GroundType type)
    {
        Tilemap.SetTile(pos, Type[(int)type]);
    }
}
