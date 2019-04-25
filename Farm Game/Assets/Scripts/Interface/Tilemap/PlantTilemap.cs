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
public class PlantTilemap : MonoBehaviour
{
    private Tilemap Map;

    public void Awake()
    {
        Map = GetComponent<Tilemap>();
    }

    public void Draw(Vector3Int pos, Plant plant)
    { 
        Map.SetTile(pos, plant.GetSprite());
    }

    public void Erase(Vector3Int pos)
    {
        Map.SetTile(pos, null);
    }
}
