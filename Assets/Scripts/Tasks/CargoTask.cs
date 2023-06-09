using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoTask : Interactable
{
    public override void Interact(bool primary)
    {
        if(!GameManager.instance.player.IsHoldingCanister())
        {
            GameManager.instance.player.PickUpCanister();
        }
        Destroy(gameObject);
    }
}
