/*  Last Edit:  [3/28/2019] - Donny
 *  Reason:     Add Documentation
 * 
 *  POTENTIAL CAPABILITIES ARE:
 *  
 *      
 *  CLASS PURPOSE:
 *      Describes what is a ground and what it can do
 */
public enum GroundType
{
    Stone, Sand, Silt, Clay, SandyClay, SiltyClay, SandySilt, Loam
}

public class GroundStats
{
    public byte Sand;
    public byte Silt;
    public byte Clay;
    public GroundType Type;

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
}
