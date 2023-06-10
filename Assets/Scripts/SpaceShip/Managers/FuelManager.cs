using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager
{
    private float fuelPercentage;

    public FuelManager(float fuelPercentage)
    {
        this.fuelPercentage = fuelPercentage;
    }

    public void SetFuelPercentage(float fuelPercentage)
    {
        this.fuelPercentage = fuelPercentage;
    }

    public float GetFuelPercentage()
    {
        return fuelPercentage;
    }

    public float ComputeCycleFuelPercentage()
    {
        float randomDeduction = Random.Range(10, 25);
        fuelPercentage = fuelPercentage - randomDeduction >= 0 ? fuelPercentage - randomDeduction : 0;
        return fuelPercentage;
    }
}
