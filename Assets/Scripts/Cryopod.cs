using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Cryopod : Interactable
{
    public override void Interact(bool primary)
    {
        GameManager.instance.EndActiveCycle();
    }
}
