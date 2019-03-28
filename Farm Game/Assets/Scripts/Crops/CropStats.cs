﻿/*  Last Edit:  [3/28/2019] - Donny
 *  Reason:     Simplify Timers and make it revolve around the Grow function
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *    
 *      
 *  CLASS PURPOSE:
 *      Defines what are crops and what they can do.
 */
using UnityEngine;

public enum GrowthState
{
    Seedling, ThirstySeedling, Mature, ThirstyMature, Producing
}

public class CropStats
{
    public GrowthState State;
    public Crop Crop;

    public int Produce;
    public int GrowthTime;          //Should be largest Value
    public int ThirstTime;          
    public int CoolDown;            
    public float GrowthChance;      //Values [0, 1)
    public int Timer = 0;

    public CropStats(Crop Crop)
    {
        State = GrowthState.Seedling;
        this.Crop = Crop;

        Produce = Crop.Produce;
        GrowthTime = Crop.GrowthTime;
        ThirstTime = Crop.ThirstTime;
        CoolDown = Crop.CoolDown;
        GrowthChance = Crop.GrowthChance;
    }
 
    //Updates the Crop 
    public bool Grow()
    {
        Timer++;
        if (State != GrowthState.Producing && (int)State % 2 == 0)
        {
            if (Timer % CoolDown == 0)
            {
                Trigger();
            }

            if (Timer % ThirstTime == 0)
            {
                State = State + 1;
            }

            if (((State == GrowthState.Mature && Timer > GrowthTime) || State != GrowthState.Mature) && Random.value < GrowthChance)
            {
                State = State + 2;
            }
            return true;
        }
        return false;
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

    public void Trigger()
    {
        foreach (AOE aoe in Crop.Specials)
        {
            aoe.Trigger();
        }
    }
}
