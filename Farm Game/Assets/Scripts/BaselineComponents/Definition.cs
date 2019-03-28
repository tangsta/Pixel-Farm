using UnityEngine;

//Object to unite all the definition in one area
[CreateAssetMenu(order = 0)]
public class Definition : ScriptableObject
{
    public int ID;
    //Inventory data
    public Plant Plant;
    //Field data
    public Crop Crop;
}
