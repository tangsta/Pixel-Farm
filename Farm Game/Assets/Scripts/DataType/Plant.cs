using UnityEngine.Tilemaps;
using UnityEngine;

public class Plant
{
    private int State;
    private float ModEvo;
    private float ModProduce;

    private PlantDef ID;
    private int EvoClock;
    private int ThirstClock;
    private int AbilityClock;
    private int DeathClock;

    public Plant(PlantDef def)
    {
        ID = def;
        State = 0;
        ModEvo = 0;
        ModProduce = 0;

        EvoClock = ID.DNA.EvoPeriod;
        ThirstClock = ID.DNA.ThirstPeriod;
        AbilityClock = ID.DNA.AbilityPeriod;
        DeathClock = ID.DNA.DeathPeriod;
    }

    public int Harvest()
    {
        if (State == ID.DNA.EvoLength)
            return (int)(ID.DNA.BaseProduce + (ID.DNA.BaseProduce * ModProduce));
        return -1;
    }

    public void Water()
    {
        if (State % 2 != 0)
            State = State - 1;
    }

    public void Age(int moisture)
    {
        Evolve(moisture);
        Thirst(moisture);
        Ability();
    }

    private void Evolve(int moisture)
    {
        if (ID.DNA.EvoPeriod < 0 || State >= ID.DNA.EvoLength - 1)
            return;
        if (EvoClock <= 0 && State % 2 == 0 && !(State >= ID.DNA.EvoLength))
        {
            if (Random.value > ID.DNA.EvoChance - (ID.DNA.EvoChance * ModEvo))
            {
                State = State + 2;
                EvoClock = ID.DNA.EvoPeriod;
                if (moisture < 0)
                {
                    ModProduce -= ID.DNA.ProduceDec;
                }
                else
                {
                    ModProduce += ID.DNA.ProduceInc;
                }
            }
        }
        else
            EvoClock--;
    }

    private void Thirst(int moisture)
    {
        if (ID.DNA.ThirstPeriod < 0 || State >= ID.DNA.EvoLength - 1)
            return;
        if (ThirstClock <= 0 && State % 2 == 0)
        {
            if (moisture < 0)
            {
                ModProduce -= ID.DNA.ProduceDec;
            }
            else
            {
                ModProduce += ID.DNA.ProduceInc;
            }
            ThirstClock--;
            State = State + 1;
            ThirstClock = ID.DNA.ThirstPeriod;
        }
        else
        {
            if (moisture < 0)
            {
                ModEvo -= ID.DNA.GrowthDec;
            }
            else
            {
                ModEvo += ID.DNA.GrowthInc;
            }
            ThirstClock--;
        }
        Debug.Log(State);
    }

    private void Ability()
    {
        if (ID.DNA.AbilityPeriod < 0)
            return;
        if (AbilityClock <= 0)
        {

            AbilityClock = ID.DNA.AbilityPeriod;
        }
        else
            AbilityClock--;
    }

    private void Death()
    {
        if (ID.DNA.DeathPeriod < 0)
            return;
        if (DeathClock <= 0)
        {

            State = 0;
            ModEvo = 0;
            ModProduce = 0;

            EvoClock = ID.DNA.EvoPeriod;
            ThirstClock = ID.DNA.ThirstPeriod;
            AbilityClock = ID.DNA.AbilityPeriod;
            DeathClock = ID.DNA.DeathPeriod;
        }
        else
            DeathClock--;
    }

    public Tile GetSprite()
    {
        return ID.Art.TileState[State];
    }
}
