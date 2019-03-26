using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public CropMap CMap; 

    public void Start()
    {
        StartCoroutine(LoopFunction(1));
    }

    private IEnumerator LoopFunction(float waitTime)
    {
        while (true)
        {
            Debug.Log("print.");
            CMap.GrowAll();
            CMap.TriggerCropEffects();

            yield return new WaitForSeconds(waitTime);
            //Second Log show passed waitTime (waitTime is float type value ) 
            Debug.Log("print1.");
        }
    }
}
