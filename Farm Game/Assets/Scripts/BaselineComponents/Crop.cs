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
public class Crop : Item
{
	[Header("Plant Attributes")]
	// required level to buy/plant?
	public string description;
	public int requriedLevel;
	public int amount;


	[Header("Donny's Attributes")]
    public Tile[] Stages;
    public AOE[] Specials;

    public int Produce;
    public int GrowthTime;
    public int ThirstTime;
    public int CoolDown;
    public float GrowthChance;


}
