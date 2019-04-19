using UnityEngine.Tilemaps;
using UnityEngine;

public class Plant
{
    private PlantDef Def;
    private int State;
    private int Clock;

    private float ModGrowth;
    private float ModProduce;

    private bool Waterable;

    public Plant(PlantDef def)
    {
        Def = def;
        State = 0;
        Clock = 0;

        ModGrowth = 0;
        ModProduce = 0;
        Waterable = false;
    }

    public int Harvest()
    {
        if (State == Def.Stage.Length - 1)
            return Def.Produce + (int)(Def.Produce * ModProduce);
        return -1;
    }

    public bool Grow()
    {
        if (Waterable)
        {
            if (Clock % Def.Time.AbilityTime == 0)
            {
                Consume();
                Emit();
            }
            if (Clock >= Def.Time.ThirstTime)
            {
                State = State + 1;
                Clock = 0;
                Waterable = false;
            }
        }
        else
        {
            if (Clock >= Def.Time.ThirstCoolDown)
            {
                Waterable = true;
            }
        }
        Clock++;
        /*
        if (Hydrated)
        {
            if (State != Def.Stage.Length - 1 && State % 2 == 0 && Hydrated)
            {
                if (Clock % Def.Time.AbilityCoolDown == 0)
                {
                    Consume();
                    Emit();
                }

                if (Clock % Def.Time.ThirstTime == 0)
                {
                    State = State + 1;
                    W = false;
                }

                if (State % 2 == 0 && Clock > Def.Time.GrowthTime + (Def.Time.GrowthTime * ModGrowth) && Random.value < Def.GrowthChance)
                {
                    State = State + 2;
                    Clock = 0;
                    return true;
                }
            }
        }
        else
        {
            if (Clock >= Def.Time.ThirstCoolDown)
            {

            }
        }*/
        return false;
    }

    public bool Water()
    {
        if (State % 2 != 0)
        {
            State = State - 1;
            Waterable = true;
            return true;
        }
        return false;
    }


    public void Consume()
    {
        ModProduce -= Def.Alter.ProDec;
        ModGrowth -= Def.Alter.GroDec;
    }

    public void Emit()
    {
        ModProduce += Def.Alter.ProInc;
        ModGrowth += Def.Alter.GroInc;
    }

    public Tile GetSprite()
    {
        Debug.Log(State);
        //if (State > 0 && State < Def.Stage.Length)
            return Def.Stage[State];
    }
}
