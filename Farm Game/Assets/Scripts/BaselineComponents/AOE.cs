using UnityEngine;

//Baseline class for all AOE functionality
public abstract class AOE : ScriptableObject
{
    public int Range;
    public int Increment;

    virtual public void Trigger() { }
}
