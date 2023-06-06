using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryoMaintenanceTask : Interactable
{
    [SerializeField] GameManager gameManager;
    [SerializeField] ParticleSystem particleSystem;

    public override void Interact()
    {
        gameManager.spaceShip.cryoManager.SetCryoPercentage(gameManager.spaceShip.cryoManager.GetCryoPercentage() >= 100f ? 100f : gameManager.spaceShip.cryoManager.GetCryoPercentage() + 1f);
        particleSystem?.Play();
    }
}
