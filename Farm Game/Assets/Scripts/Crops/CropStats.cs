using UnityEngine;

//Used to control avaliable plant states
public enum GrowthState
{
    Seedling, ThirstySeedling, Mature, ThirstyMature, Producing
}

public class CropStats
{
    public GrowthState State;
    public Crop Crop;

    //Local Crop Values
    public int Produce;
    public int GrowthTime;
    //ThirstTime must be smaller than GrowthTime
    public int ThirstTime;
    //Must be between 0 - 0.99999...
    public float GrowthChance;
    //Count chance cycles, use as a base for growth and water stages
    public int Timer = 0;

    public CropStats(Crop Crop)
    {
        State = GrowthState.Seedling;
        this.Crop = Crop;

        Produce = Crop.Produce;
        GrowthTime = Crop.GrowthTime;
        ThirstTime = Crop.ThirstTime;
        GrowthChance = Crop.GrowthChance;
    }
 
    //Grow based on conditions of crop
    public void Grow()
    {
        Timer++;
        if (State != GrowthState.Producing && (int)State % 2 == 0)
        {
            if (Timer % ThirstTime == 0)
            {
                State = State + 1;
            }

            float randValue = Random.value;
            if (((State == GrowthState.Mature && Timer > GrowthTime) || State != GrowthState.Mature) && randValue < GrowthChance)
            {
                State = State + 2;
            }
        }
    }

    public bool Water()
    {
        if ((int)State % 2 != 0)
        {
            State = State - 1;
            return true;
        }
        else
        {
            Debug.Log("You cant water this");
            return false;
        }
    }

    //Preemptive AOE functionality
    public void TriggerSpecials()
    {
        foreach (AOE aoe in Crop.Specials)
        {
            aoe.Trigger();
        }
    }
}
