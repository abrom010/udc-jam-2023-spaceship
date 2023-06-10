using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceManager
{
    public float totalDistanceTraveled;
    public float goalDistance;

    private float fuelEfficiency = 2f;

    public DistanceManager(float distanceToDestination)
    {
        goalDistance = distanceToDestination;
    }

    public void ComputeDistanceForCycle(float fuelUsedPercentage)
    {
        float distanceTraveled = fuelUsedPercentage * fuelEfficiency;
        totalDistanceTraveled = totalDistanceTraveled + distanceTraveled >= goalDistance ? goalDistance : totalDistanceTraveled + distanceTraveled;
    }

    public bool IsDestinationReached()
    {
        return totalDistanceTraveled >= goalDistance;
    }
}
