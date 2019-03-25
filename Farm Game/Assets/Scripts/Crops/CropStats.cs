using UnityEngine;
using UnityEngine.Tilemaps;

public enum GrowthState
{
    Seedling, Mature, Producing
}

public class CropStats
{
    public GrowthState State;
    public Crop Crop;

    public Tile[] Stages;
    public int Produce;
    public float GrowthTime;
    public float WaterTime;
    public float GrowthChance;
    public AOE[] Specials;

    public CropStats(Crop Crop)
    {
        State = GrowthState.Seedling;
        this.Crop = Crop;

        Produce = Crop.Produce;
        GrowthTime = Crop.GrowthTime;
        WaterTime = Crop.WaterTime;
        GrowthChance = Crop.GrowthChance;
        Specials = Crop.Specials;
    }
 
    public void Grow()
    {   
        if (State != GrowthState.Producing && Random.Range(0, 1) > GrowthChance)
        {
            State = State + 1;
        }
    }

    public void TriggerSpecials()
    {
        foreach (AOE aoe in Specials)
        {
            aoe.Trigger();
        }
    }
}
