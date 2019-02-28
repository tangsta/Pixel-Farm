using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TileClick : MonoBehaviour
{
    private PlotBase tile;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 PointClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int worldPoint = new Vector3Int(Mathf.FloorToInt(PointClick.x),
                Mathf.FloorToInt(PointClick.y), 0);

            var tiles = PlotManager.instance.tiles;

            if(tiles.TryGetValue(worldPoint, out tile))
            {
                Debug.Log(tile.Name);
                tile.Tilemap.SetTileFlags(tile.LocalPlace, TileFlags.None);
                tile.Tilemap.SetColor(tile.LocalPlace, Color.blue);
            }
        }
    }
}
