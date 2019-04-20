using UnityEngine;

[CreateAssetMenu(menuName = "Plants/DNA", order = 3)]
public class PlantDNA : ScriptableObject
{
    public int BaseProduce;
    public float EvoChance;
    public int EvoLength;

    public int EvoPeriod;
    public int ThirstPeriod;
    public int AbilityPeriod;
    public int DeathPeriod;

    public float ProduceDec;
    public float ProduceInc;

    public float GrowthDec;
    public float GrowthInc;
}
