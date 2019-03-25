using UnityEngine;

[CreateAssetMenu]
public class AOE : ScriptableObject
{
    public int Range;
    public int Increment;

    virtual public void Trigger() { }
}
