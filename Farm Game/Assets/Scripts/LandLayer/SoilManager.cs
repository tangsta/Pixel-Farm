﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoilManager : MonoBehaviour
{
    public static SoilManager instance;
    public Tilemap Tilemap;
    public Tile[] Tiles;

    public Dictionary<Vector3, SoilPlot> SoilPlots;

    //Updates the soil types every frame
    public void Update()
    {
        foreach (KeyValuePair<Vector3, SoilPlot> entry in SoilPlots)
        {
            entry.Value.Tile = Tiles[entry.Value.UpdateTile()];
            Tilemap.SetTile(entry.Value.LocalPlace, entry.Value.Tile);
        }
    }

    //SoilManager's Start
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GetLandPlots();
    }

    //Initializes our SoilPlot reference (Dictionary SoilPlots)
    private void GetLandPlots()
    {
        SoilPlots = new Dictionary<Vector3, SoilPlot>();
        foreach(Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            if (!Tilemap.HasTile(localPlace)) continue;
            SoilPlot soil = SetSoil(Tilemap, localPlace);
            SoilPlots.Add(soil.WorldLocation, soil);
        }
    }

    //Figures out SoilPlot from a given Tile
    public SoilPlot SetSoil(Tilemap Tilemap, Vector3Int pos)
    {
        byte sand, silt, clay, orgScore;
        int TileType;
        string name;

        TileBase check = Tilemap.GetTile(pos);
        for (TileType = 0; TileType < Tiles.Length; TileType++)
        {
            if (Tiles[TileType] == check)
            {
                break;
            }
        }
        
        switch (TileType)
        {
            case 0:             //Stone
                sand = 0;
                silt = 0;
                clay = 0;
                orgScore = 0;
                name = "stone";
                break;
            case 1:             //Clay
                sand = 35;
                silt = 40;
                clay = 50;
                orgScore = 0;
                name = "clay";
                break;
            case 2:             //Silt
                sand = 10;
                silt = 100;
                clay = 15;
                orgScore = 0;
                name = "silt";
                break;
            case 3:             //Sand
                sand = 113;
                silt = 6;
                clay = 6;
                orgScore = 0;
                name = "sand";
                break;
            case 4:             //Sand_Clay
                sand = 75;
                silt = 25;
                clay = 25;
                orgScore = 0;
                name = "sand_clay";
                break;
            case 5:             //Silt_Clay
                sand = 25;
                silt = 75;
                clay = 25;
                orgScore = 0;
                name = "silt_clay";
                break;
            case 6:             //Sand_Silt
                sand = 75;
                silt = 40;
                clay = 10;
                orgScore = 0;
                name = "sand_silt";
                break;
            case 7:             //Loam
                sand = 100;
                silt = 100;
                clay = 100;
                orgScore = 0;
                name = "loam";
                break;
            default:
                sand = 0;
                silt = 0;
                clay = 0;
                orgScore = 0;
                name = "NULL";
                Debug.Log("TILE DOES NOT EXIST, Are you using the right one?");
                break;
        }

        SoilPlot output = new SoilPlot
        {
            Sand = sand,
            Silt = silt,
            Clay = clay,
            OrgScore = orgScore,

            Tile = Tiles[TileType],
            LocalPlace = pos,
            WorldLocation = Tilemap.CellToWorld(pos),
            Name = name,
        };

        return output;
    }

}
