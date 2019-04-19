using UnityEngine.Tilemaps;
using UnityEngine;

public class Plant
{
    private PlantDef Def;
    private int State;
    private int Clock;

    private float ModGrowth;
    private float ModProduce;

    public Plant(PlantDef def)
    {
        Def = def;
        State = 0;
        Clock = 0;

        ModGrowth = 0;
        ModProduce = 0;
    }

    public int Harvest()
    {
        if (State == Def.Stage.Length - 1)
            return Def.Produce + (int)(Def.Produce * ModProduce);
        return -1;
    }

    public bool Grow()
    {
        Clock++;
        if (State != Def.Stage.Length - 1 && State % 2 == 0)
        {
            if (Clock % Def.Time.CoolDown == 0)
            {
                Consume();
                Emit();
            }

            if (Clock % Def.Time.ThirstTime == 0)
                State = State + 1;

            if (Clock > Def.Time.GrowthTime + (Def.Time.GrowthTime * ModGrowth) && Random.value < Def.GrowthChance)
            {
                State = State + 2;
                Clock = 0;
            }
            return true;
        }
        return false;
    }

    public bool Water()
    {
        if (State % 2 != 0)
        {
            State = State - 1;
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
        return Def.Stage[State];
    }
}
