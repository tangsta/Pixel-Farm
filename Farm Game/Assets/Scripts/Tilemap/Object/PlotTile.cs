using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif
/*
 * ToDo
 * Create PlotTile assets
 * Fill The Tilemap with PlotTiles
 * 
 */
 

public class PlotTile : Tile
{
    Sprite[] Sprites;
    Sprite origin;
    //string type;

    //Used to update rendering and choosing surrounding tiles
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        base.RefreshTile(position, tilemap);
    }

    //Determines which sprite is used based on surrounding tiles
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
    }

    //Virtual ? or nah 
    public bool sameTile(ITilemap itilemap, Vector3Int position)
    {
        return itilemap.GetTile(position) == this;
    }

    //Determine which sprite to use
    private int GetIndex(byte mask)
    {
        return -1;
    }

    //Determine which rotation to use based on surrounding tiles
    private Quaternion GetRotation(byte mask)
    {
        return Quaternion.Euler(0f, 0f, 0f);
    }


#if UNITY_EDITOR
    //Adds a helper that adds a menu item to create PlotTile Asset
    [MenuItem("Assets/Create/PlotTile")]
    public static void CreatePlotTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Plot Tile",
            "New Plot Tile", "Asset", "Save Plot Tile", "Assets");
        if (path == "") { return; }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<PlotTile>(), path);
    }
#endif
}
