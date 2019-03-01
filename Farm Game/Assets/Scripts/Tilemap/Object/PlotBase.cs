using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlotBase
{ 
    public string Name { get; set; }

    public TileBase Tile { get; set; }

    public Tilemap Tilemap { get; set; }

    public Vector3Int LocalPlace { get; set; }

    public Vector3 WorldLocation { get; set; }


}
