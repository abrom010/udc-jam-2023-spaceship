using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryoMaintenanceTask : Interactable
{
    [SerializeField] GameManager gameManager;

    public override void Interact()
    {
        gameManager.spaceShip.cryoManager.SetCryoPercentage(100f);
    }
}
