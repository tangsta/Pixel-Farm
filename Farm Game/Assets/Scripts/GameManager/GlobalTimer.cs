using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
	public double cycleTime; // the cycle time you want to loop around 
	public double currentTimer;

    // Update is called once per frame
    void Update()
    {
    	PhaseTimer();   
    }

    public void PhaseTimer()
    {
    	currentTimer = currentTimer - Time.deltaTime;
    	if(currentTimer < 0)
    	{
    		currentTimer = cycleTime;
    	}
    }
}
