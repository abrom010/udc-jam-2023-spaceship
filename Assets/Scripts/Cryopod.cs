using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Cryopod : Interactable
{
    private void Start()
    {
        etext = "slumber";
    }
    public override void Interact(bool primary)
    {
        GameManager.instance.EndActiveCycle();
    }
}
