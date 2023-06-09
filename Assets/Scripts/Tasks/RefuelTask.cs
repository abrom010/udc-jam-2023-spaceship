using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelTask : Interactable
{
    public override void Interact(bool primary)
    {
        if(GameManager.instance.player.IsHoldingCanister())
        {
            GameManager.instance.player.UseCanister();
            GameManager.instance.spaceShip.fuelManager.SetFuelPercentage(GameManager.instance.spaceShip.fuelManager.GetFuelPercentage() + 25f);
            if(GameManager.instance.spaceShip.fuelManager.GetFuelPercentage() > 100f) GameManager.instance.spaceShip.fuelManager.SetFuelPercentage(100f);
        }
    }
}