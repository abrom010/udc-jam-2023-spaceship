using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoTask : Interactable
{
    public AudioClip pickupClip;

    private void Start()
    {
        etext = "pick up";
    }

    public override void Interact(bool primary)
    {
        if(!GameManager.instance.player.IsHoldingCanister())
        {
            AudioSource.PlayClipAtPoint(pickupClip, transform.position, 0.5f);
            GameManager.instance.player.PickUpCanister();
        }
        Destroy(gameObject);
    }
}
