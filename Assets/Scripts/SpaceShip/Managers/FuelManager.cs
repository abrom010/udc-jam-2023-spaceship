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
}
