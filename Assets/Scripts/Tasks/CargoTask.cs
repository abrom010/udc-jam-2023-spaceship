using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoTask : Interactable
{
    public override void Interact(bool primary)
    {
        Player player = gameManager.GetComponent<Player>();
        if(!player.IsHoldingCanister())
        {
            player.PickUpCanister();
        }
        Destroy(gameObject);
    }
}
