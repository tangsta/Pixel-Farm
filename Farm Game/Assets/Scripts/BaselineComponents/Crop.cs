/*  Last Edit:  [3/28/2019] - Donny
 *  Reason:     Added documentation
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *  
 *      
 *  CLASS PURPOSE:
 *      Instatiated Crops are used to hold default values to represent different crops
 */
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Crop : ScriptableObject
{
    public Tile[] Stages;
    public AOE[] Specials;

    public int Produce;
    public int GrowthTime;
    public int ThirstTime;
    public int CoolDown;
    public float GrowthChance;
}
