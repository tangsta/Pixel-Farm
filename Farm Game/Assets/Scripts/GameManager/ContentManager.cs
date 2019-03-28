using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
//Tracks all item and relates them to their various definitions for various tasks
public class ContentManager : ScriptableObject
{
    public static int ID = 0;
    public Dictionary<int, ScriptableObject> IDDictionary;

    //Array used to preinitialize data 
    public Definition[] CropDefinition;

    //Preinitialize item
    public void Awake()
    {
        IDDictionary = new Dictionary<int, ScriptableObject>();
        for (int i = 0; i < CropDefinition.Length; i++)
        {
            Definition def = CropDefinition[i];
            if (def != null)
            {
                ID = def.ID;
                IDDictionary.Add(def.ID, def);
                ID++;
            }
        }
    }

    //Reference for new additions
    /*
    public void AddContent(ScriptableObject definition)
    {
        ContentDiction.Add(ID++, definition);
    }
    */
}
