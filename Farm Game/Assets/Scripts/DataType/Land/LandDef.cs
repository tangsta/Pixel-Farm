using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Lands/Land", order = 1)]
public class LandDef : ScriptableObject
{
    public Tile[] Sprite;
    //May have effects in future
}
