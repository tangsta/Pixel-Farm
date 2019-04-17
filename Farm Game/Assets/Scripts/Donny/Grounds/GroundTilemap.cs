<<<<<<< HEAD:Farm Game/Assets/Scripts/Grounds/GroundTilemap.cs
﻿/*  Last Edit:  [3/28/2019] - Donny
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
    public Tilemap Map;

    public void Replace(Vector3Int pos, GroundState type)
    {
        Map.SetTile(pos, Type[(int)type]);
    }
}
=======
﻿/*  Last Edit:  [3/28/2019] - Donny
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
    public Tilemap Map;

    public void Replace(Vector3Int pos, GroundType type)
    {
        Map.SetTile(pos, Type[(int)type]);
    }
}
>>>>>>> PlantLayer:Farm Game/Assets/Scripts/Donny/Grounds/GroundTilemap.cs
