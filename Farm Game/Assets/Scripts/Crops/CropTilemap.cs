/*  Last Edit:  [3/28/2019] - Donny
 *  Reason:     Isolate functionality and create general modular functions
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *      Shade Tiles in a color
 *      Refresh Tiles (Connected textures implementation)
 *      Swap Tiles with a new Tile
 *      
 *  CLASS PURPOSE:
 *      A interface to a Tilemap that focuses on crops.
 */
using UnityEngine;
using UnityEngine.Tilemaps;

[AddComponentMenu("Tilemap/Crop Tilemap")]
public class CropTilemap : MonoBehaviour
{
    private Tilemap Tilemap;

    public void Awake()
    {
        Tilemap = GetComponent<Tilemap>();
    }

    public void Replace(Vector3Int pos, Crop crop, GrowthState state)
    { 
        Tilemap.SetTile(pos, crop.Stages[(int)state]);
    }

    public void Clear(Vector3Int pos)
    {
        Tilemap.SetTile(pos, null);
    }
}
