using UnityEngine;

[CreateAssetMenu(menuName = "Plants/Time", order = 2)]
public class PlantTime : ScriptableObject
{
    public int GrowthTime;
    public int ThirstTime;
    public int CoolDown;
}
