using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryoMaintenanceTask : Interactable
{
    [SerializeField] ParticleSystem particleSystem;

    public override void Interact(bool primary)
    {
        gameManager.spaceShip.cryoManager.SetCryoPercentage(gameManager.spaceShip.cryoManager.GetCryoPercentage() >= 100f ? 100f : gameManager.spaceShip.cryoManager.GetCryoPercentage() + 1f);
        particleSystem?.Play();
    }
}
