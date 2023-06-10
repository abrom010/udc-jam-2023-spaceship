using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip
{
    public SurvivorManager survivorManager;
    public DistanceManager distanceManager;
    public CryoManager cryoManager;
    public FuelManager fuelManager;

    public SpaceShip(int initialSurvivalCount = 100, float distanceToDestination = 1000f, float cryoPercentage = 100f, float fuelPercentage = 100f)
    {
        survivorManager = new SurvivorManager(10000);
        distanceManager = new DistanceManager(1000f);
        cryoManager = new CryoManager(100f);
        fuelManager = new FuelManager(100f);
    }
}
