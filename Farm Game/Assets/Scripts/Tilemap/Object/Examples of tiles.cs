/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;


//This class is a reference for future tiles when we work on textures of the game

public class TileLand : Tile
{
    //Allows sprites to be accessed in Unity
    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Sprite preview;

    //Able to refresh (8) tiles relative to click
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                //Get the position surrounding the tile clicked
                Vector3Int nPos = new Vector3Int(position.x + x,
                    position.y + y, position.z);
                if(HasTile(tilemap, position))
                {
                    //Refreshes tile at that pos
                    tilemap.RefreshTile(nPos);
                }
            }
        }
    }
    //Checks if the tile is the same type
    private bool HasTile(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

    //Changes the sprite used
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        string composition = string.Empty;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x != 0 || y != 0)
                {
                    if (HasTile(tilemap, new Vector3Int(position.x + x,
                        position.y + y, position.z)))
                    {
                        composition += 'H';
                    }
                    else
                    {
                        composition += 'E';
                    }
                }
            }
        }
        tileData.sprite = sprites[0];

        //if (composition[1] == 'E' && composition[3] == 'E')
    }

    

#if UNITY_EDITOR
    //Adds it to the Create menu in the Tiles section
    [MenuItem("Assets/Create/Tiles/TileLand")]
    public static void CreateTileLand()
    {
        string path = EditorUtility.SaveFilePanelInProject(
            "Save Tile Land", "New Tile Land", "Asset", 
            "Save Tile Land", "Assets");
        if (path == "") { return; }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TileLand>(), path);
    }
#endif
}
*/
