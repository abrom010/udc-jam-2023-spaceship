using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelTask : Interactable
{
    public override void Interact(bool primary)
    {
        Player player = gameManager.GetComponent<Player>();
        if(player.IsHoldingCanister())
        {
            player.UseCanister();
            gameManager.spaceShip.fuelManager.SetFuelPercentage(100f);
        }
    }
}