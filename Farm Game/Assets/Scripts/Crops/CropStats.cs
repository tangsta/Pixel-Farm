using UnityEngine;

public enum GrowthState
{
    Seedling, Mature, Producing
}

public class CropStats
{
    public GrowthState State;
    public Crop Crop;

    //Local Crop Values
    public int Produce;
    public float GrowthTime;
    public float WaterTime;
    //Must be between 0 - 0.99999...
    public float GrowthChance;

    public CropStats(Crop Crop)
    {
        State = GrowthState.Seedling;
        this.Crop = Crop;

        Produce = Crop.Produce;
        GrowthTime = Crop.GrowthTime;
        WaterTime = Crop.WaterTime;
        GrowthChance = Crop.GrowthChance;
    }
 
    public void Grow()
    {
        float randValue = Random.value;
        if (State != GrowthState.Producing && randValue < GrowthChance) //&& Random.Range(0, 1) > GrowthChance)
        {
            State = State + 1;
        }
    }

    public void TriggerSpecials()
    {
        foreach (AOE aoe in Crop.Specials)
        {
            aoe.Trigger();
        }
    }
}
