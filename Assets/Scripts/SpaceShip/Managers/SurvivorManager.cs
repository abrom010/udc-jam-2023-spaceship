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
        int cycleDeathCount = Mathf.RoundToInt(cryoPercentage > 80 ? 0 : (250 + Random.Range(50, 750)) / (cryoPercentage / 10f));
        survivorCount = survivorCount - cycleDeathCount < 0 ? 0 : survivorCount - cycleDeathCount;
    }

    public int GetSurvivorCount()
    {
        return survivorCount;
    }
}
