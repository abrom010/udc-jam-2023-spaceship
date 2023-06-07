using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoTask : Interactable
{
    // carry canister on player (either on back or hand)
    public override void Interact(bool primary)
    {
        if(!GameManager.instance.player.IsHoldingCanister())
        {
            GameManager.instance.player.PickUpCanister();
        }
        Destroy(gameObject);
    }
}
