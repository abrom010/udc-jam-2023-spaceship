using System.Collections;
using System.Collections.Generic;
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
}
