using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CryoManager
{
    private float cryoPercentage;

    public CryoManager(float cryoPercentage)
    {
        this.cryoPercentage = cryoPercentage;
    }

    public void SetCryoPercentage(float cryoPercentage)
    {
        this.cryoPercentage = cryoPercentage;
    }

    public float GetCryoPercentage()
    {
        return cryoPercentage;
    }

    public float ComputeCycleCryoPercentage()
    {
        float randomDeduction = Random.Range(10, 40);
        cryoPercentage = cryoPercentage - randomDeduction >= 0 ? cryoPercentage - randomDeduction : 0;
        return cryoPercentage;
    }
}
