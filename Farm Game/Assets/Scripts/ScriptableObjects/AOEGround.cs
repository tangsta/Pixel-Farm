using UnityEngine;

[CreateAssetMenu]
public class AOEGround : AOE
{
    public GroundMap Ground;
    public int GroundValue;

    // 0 - Sand    1 - Silt    2 - Clay
    public void Trigger(Vector3Int pos)
    {
        switch (GroundValue)
        {
            case 0:
                Ground.AOESand(pos, Range, Increment);
                break;
            case 1:
                Ground.AOESilt(pos, Range, Increment);
                break;
            case 2:
                Ground.AOEClay(pos, Range, Increment);
                break;
            default:
                Debug.Log("AOE GROUNDVALUE NOT DEFINED");
                break;
        }
        Ground.GroundUpdate();
    }
}
