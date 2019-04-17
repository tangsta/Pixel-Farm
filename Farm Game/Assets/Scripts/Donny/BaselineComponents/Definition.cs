using UnityEngine;

//Object to unite all the definition in one area
[CreateAssetMenu(order = 0)]
public class Definition : ScriptableObject
{
    public int ID;
    //Field data
    public Crop Crop;
}
