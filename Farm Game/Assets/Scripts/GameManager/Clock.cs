using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Map Map;
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
            Map.GrowAll();
            // CMap.WaterAll();

            yield return new WaitForSeconds(waitTime);
            //Second Log show passed waitTime (waitTime is float type value ) 
            // Debug.Log("print1.");
        }
    }
}
