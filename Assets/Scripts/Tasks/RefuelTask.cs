using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RefuelTask : Interactable
{
    [SerializeField] AudioClip pourMilkClip;

    public override void Interact(bool primary)
    {
        if(GameManager.instance.player.IsHoldingCanister())
        {
            AudioSource.PlayClipAtPoint(pourMilkClip, transform.position, 0.75f);
            GameManager.instance.player.UseCanister();
            GameManager.instance.spaceShip.fuelManager.SetFuelPercentage(GameManager.instance.spaceShip.fuelManager.GetFuelPercentage() + 25f);
            if(GameManager.instance.spaceShip.fuelManager.GetFuelPercentage() > 100f) GameManager.instance.spaceShip.fuelManager.SetFuelPercentage(100f);
        }
    }

    public override void Highlight()
    {
        
    }

    public override void ResetHighlight()
    {
        
    }

}