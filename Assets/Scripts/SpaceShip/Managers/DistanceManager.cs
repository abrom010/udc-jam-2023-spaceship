using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceManager
{
    private float totalDistanceTraveled;
    private float goalDistance;

    private float fuelEfficiency;

    public DistanceManager(float distanceToDestination)
    {
        goalDistance = distanceToDestination;
    }

    public void ComputeDistanceForCycle(float fuelPercentage)
    {
        float distanceTraveled = fuelPercentage * fuelEfficiency;
        totalDistanceTraveled = totalDistanceTraveled + distanceTraveled >= goalDistance ? goalDistance : totalDistanceTraveled + distanceTraveled;
    }

    public bool IsDestinationReached()
    {
        return totalDistanceTraveled >= goalDistance;
    }
}
