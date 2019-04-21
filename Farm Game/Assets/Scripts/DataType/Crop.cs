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

[CreateAssetMenu]
public class Crop : Item
{
	[Header("Plant Attributes")]
	// required level to buy/plant?
	public string description;
	public int requriedLevel;
	public int amount;
}
