using UnityEngine;

//AOE functionality affecting the CropMap
[CreateAssetMenu]
public class AOECrop : AOE
{
    public CropMap Crop;
    public int CropValue;


    //0 - Produce  1 - Growth
    public void Trigger(Vector3Int pos)
    {
        switch (CropValue)
        {
            case 0:
                Crop.AOEProduce(pos, Range, Increment);
                break;
            case 1:
                Crop.AOEGrowth(pos, Range, Increment);
                break;
            default:
                Debug.Log("AOE CROPVALUE NOT DEFINED");
                break;
        }
    }
}
