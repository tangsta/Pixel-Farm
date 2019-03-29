using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public CropHandler CMap;
    public float WaitTime;

    public void Start()
    {

        StartCoroutine(LoopFunction(WaitTime));
    }

    private IEnumerator LoopFunction(float waitTime)
    {
        while (true)
        {
            // Debug.Log("print.");
            CMap.GrowAll();
            CMap.TriggerAllCrop();
            CMap.WaterAll();

            yield return new WaitForSeconds(waitTime);
            //Second Log show passed waitTime (waitTime is float type value ) 
            // Debug.Log("print1.");
        }
    }
}
