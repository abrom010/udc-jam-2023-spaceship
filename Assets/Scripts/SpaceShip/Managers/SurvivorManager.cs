using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorManager
{
    private int survivorCount;

    public SurvivorManager(int initialSurvivalCount)
    {
        survivorCount = initialSurvivalCount;
    }

    public void ComputeSurvivorsForCycle(float cryoPercentage)
    {
        int cycleDeathCount = Mathf.RoundToInt(cryoPercentage > 75 ? 0 : (35 + Random.Range(5, 25)) / cryoPercentage);
        survivorCount = survivorCount - cycleDeathCount < 0 ? 0 : survivorCount - cycleDeathCount;
    }

    public int GetSurvivorCount()
    {
        return survivorCount;
    }
}
