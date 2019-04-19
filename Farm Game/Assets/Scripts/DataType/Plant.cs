using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Plants/Plant", order = 1)]
public class Plant : ScriptableObject
{
    public Tile[] Stage;
    //public Effect[] Consumers;
    //public Effect[] Emitters;
    public int Produce;
    public PlantAlter Alter;
    public PlantTime Time;
    public float GrowthChance;

    private float ModGrowth;
    private float ModProduce;
    private int State;
    private int Clock;

    public int Harvest()
    {
        if (State == Stage.Length - 1)
            return Produce + (int)(Produce * ModProduce);
        return -1;
    }

    public bool Grow()
    {
        Clock++;
        if (State != Stage.Length - 1 && State % 2 == 0)
        {
            if (Clock % Time.CoolDown == 0)
            {
                Consume();
                Emit();
            }

            if (Clock % Time.ThirstTime == 0)
                State = State + 1;

            if (Clock > (Time.GrowthTime * ModGrowth) && Random.value < GrowthChance)
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
        ModProduce -= Alter.ProDec;
        ModGrowth -= Alter.GroInc;
    }

    public void Emit()
    {
        ModProduce += Alter.ProInc;
        ModGrowth += Alter.GroInc;
    }

    public int GetState()
    {
        return State;
    }
}

