﻿/*  Last Edit:  [4/17/2019] - Donny
 *  Reason:     Redo Land to simplify 8 ground types to 4
 *              Abstracting attribute values for other uses (textures, plant requirements, etc.)
 *              Enforcing value limits through Mes and Add methods
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *  
 *      
 *  CLASS PURPOSE:
 *      Determines the ground type and what it does in it states
 */
using UnityEngine.Tilemaps;

public class Land 
{
    private int GrainAmount;              //Range 0 - 4096
    private int OrganicLevel;             //Range 0 - 100
    private int MoistureLevel;            //Range 0 - 100
    private byte ID;

    public Land(int GrainAmount, int OrganicLevel, int MoistureLevel)
    {
        this.GrainAmount = GrainAmount;
        this.OrganicLevel = OrganicLevel;
        this.MoistureLevel = MoistureLevel;
        ID = GetState();
    }

    public Land()
    {
        GrainAmount = 0;
        OrganicLevel = 0;
        MoistureLevel = 0;
    }

    public void AddGrain(int val)
    {
        if (GrainAmount + val < 0)
            GrainAmount = 0;
        else if (GrainAmount + val > 4096)
            GrainAmount = 4096;
        else
            GrainAmount += val;
    }

    public void AddOrg(int val)
    {
        if (OrganicLevel + val < 0)
            GrainAmount = 0;
        else if (OrganicLevel + val > 100)
            GrainAmount = 100;
        else
            GrainAmount += val;
    }

    public void AddMoist(int val)
    {
        if (MoistureLevel + val < 0)
            MoistureLevel = 0;
        else if (MoistureLevel + val > 100)
            MoistureLevel = 100;
        else
            MoistureLevel += val;
    }

    public byte GetState()
    {
        if (GrainAmount < 410)
            ID = 0;
        else
        {
            if (OrganicLevel >= 20)
            {
                if (GrainAmount > 3891 && OrganicLevel > 80 && MoistureLevel > 80)
                    ID = 3;
                else
                    ID = 2;
            }
            else
                ID = 1;
        }
        return ID;
    }
    
    //Reveals attributes from a scale of 0 - 10
    public int MesGrain()
    {
        return (GrainAmount / 4096) * 10;
    }

    public int MesOrg()
    {
        return OrganicLevel / 10;
    }

    public int MesMoist()
    {
        return MoistureLevel / 10;
    }

}
