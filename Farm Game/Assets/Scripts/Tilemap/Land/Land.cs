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
public class Land
{
    private int GrainAmount;              //Range 0 - 4096
    private int OrganicLevel;             //Range 0 - 100
    private int MoistureLevel;            //Range 0 - 100
    private byte? State;
    /*  Type List
    *  0   -Stone
    *  1   -Sand
    *  2   -Dirt
    *  3   -Water
    */

    public Land(int GrainAmount, int OrganicLevel, int MoistureLevel)
    {
        this.GrainAmount = GrainAmount;
        this.OrganicLevel = OrganicLevel;
        this.MoistureLevel = MoistureLevel;
        State = UpdateState();
    }

    public Land()
    {
        GrainAmount = 0;
        OrganicLevel = 0;
        MoistureLevel = 0;
        State = null;
    }

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

    public byte UpdateState()
    {
        switch(State)
        {
            case 2:
                if (GrainAmount < 410)
                    State = 0;
                else if (OrganicLevel < 20)
                    State = 1;
                else if (GrainAmount > 3891 && OrganicLevel > 80 && MoistureLevel > 80)
                    State = 3;
                break;
            case 0:
                if (GrainAmount >= 410)
                    State = 1;
                break;
            case 1:
                if (GrainAmount < 410)
                    State = 0;
                else if (OrganicLevel >= 20)
                    State = 2;
                break;
            case 3:
                if (GrainAmount < 3891 || OrganicLevel < 80 || MoistureLevel < 80)
                    State = 2;
                break;
        }
        return State ?? default(byte);
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
}
