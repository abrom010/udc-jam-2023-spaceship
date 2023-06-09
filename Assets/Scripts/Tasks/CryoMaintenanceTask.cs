using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryoMaintenanceTask : Interactable
{
    [SerializeField] ParticleSystem particleSystem;

    public override void Interact(bool primary)
    {
        GameManager.instance.spaceShip.cryoManager.SetCryoPercentage(GameManager.instance.spaceShip.cryoManager.GetCryoPercentage() >= 100f ? 100f : GameManager.instance.spaceShip.cryoManager.GetCryoPercentage() + 1f);
        particleSystem?.Play();
    }
}
