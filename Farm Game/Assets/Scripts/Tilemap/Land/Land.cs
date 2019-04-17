/*  Last Edit:  [4/17/2019] - Donny
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
/*
public enum GroundType
{
   Stone, Sand, Silt, Clay, SandyClay, SiltyClay, SandySilt, Loam
}
*/

public enum GroundState
{
    Stone, Sand, Dirt, Water
}

public class Land
{
    private int GrainAmount;              //Range 0 - 4096
    private int OrganicLevel;             //Range 0 - 100
    private int MoistureLevel;            //Range 0 - 100
    private GroundState State;
    
    //public byte Sand;
    //public byte Silt;
    //public byte Clay;
    //public GroundType Type;
    
    public Land(int GrainAmount, int OrganicLevel, int MoistureLevel)
    {
        this.GrainAmount = GrainAmount;
        this.OrganicLevel = OrganicLevel;
        this.MoistureLevel = MoistureLevel;
        State = GroundState.Dirt;
        UpdateState();
    }

    public Land()
    {
        GrainAmount = 0;
        OrganicLevel = 0;
        MoistureLevel = 0;
        State = GroundState.Stone;
    }

    /*
    public GroundStats(byte Sand, byte Silt, byte Clay)
    {
        this.Sand = Sand;
        this.Silt = Silt;
        this.Clay = Clay;
        UpdateType();
    }

    public GroundStats()
    {
        Sand = 0;
        Silt = 0;
        Clay = 0;
        Type = 0;
    }
   */

    public void GrainAdd(int val)
    {
        if (GrainAmount + val < 0)
            GrainAmount = 0;
        else if (GrainAmount + val > 4096)
            GrainAmount = 4096;
        else
            GrainAmount += val;
    }

    public void OrganicAdd(int val)
    {
        if (OrganicLevel + val < 0)
            GrainAmount = 0;
        else if (OrganicLevel + val > 100)
            GrainAmount = 100;
        else
            GrainAmount += val;
    }

    public void MoistureAdd(int val)
    {
        if (MoistureLevel + val < 0)
            MoistureLevel = 0;
        else if (MoistureLevel + val > 100)
            MoistureLevel = 100;
        else
            MoistureLevel += val;
    }

    public void UpdateState()
    {
        switch(State)
        {
            case GroundState.Dirt:
                if (GrainAmount < 410)
                    State = GroundState.Stone;
                else if (OrganicLevel < 20)
                    State = GroundState.Sand;
                else if (GrainAmount > 3891 && OrganicLevel > 80 && MoistureLevel > 80)
                    State = GroundState.Water;
                break;
            case GroundState.Stone:
                if (GrainAmount >= 410)
                    State = GroundState.Sand;
                break;
            case GroundState.Sand:
                if (GrainAmount < 410)
                    State = GroundState.Stone;
                else if (OrganicLevel >= 20)
                    State = GroundState.Dirt;
                break;
            case GroundState.Water:
                if (GrainAmount < 3891 || OrganicLevel < 80 || MoistureLevel < 80)
                    State = GroundState.Dirt;
                break;
        }
    }


    //Reveals attributes from a scale of 0 - 10
    public int MesGrain()
    {
        return (GrainAmount / 4096) * 10;
    }

    public int MesOrganic()
    {
        return OrganicLevel / 10;
    }

    public int MesMoisture()
    {
        return MoistureLevel / 10;
    }

    public GroundState GetState()
    {
        return State;
    }

    /*
    public void UpdateType()
    {
        float total = Sand + Silt + Clay;

        float perSand = 0;
        float perSilt = 0;
        float perClay = 0;

        if (total < 125)
        {
            Type = GroundType.Stone;
        }
        else
        {
            perSand = Sand / total;
            perSilt = Silt / total;
            perClay = Clay / total;

            if (perClay >= 0.40)
            {
                Type = GroundType.Clay;
            }
            else if (perSilt >= 0.80)
            {
                Type = GroundType.Silt;
            }
            else if (perSand >= 0.90)
            {
                Type = GroundType.Sand;
            }
            else if ((perSilt < 0.30) && (perClay < 0.40 && perSand > 0.50))
            {
                Type = GroundType.SandyClay;
            }
            else if ((perSand < 0.30) && (perClay < 0.40 && perSilt > 0.50))
            {
                Type = GroundType.SiltyClay;
            }
            else if ((perClay < 0.10) && (perSilt > 0.30 && perSand < 0.70))
            {
                Type = GroundType.SandySilt;
            }
            else
            {
                Type = GroundType.Loam;
            }
        }
    }
    */
}
