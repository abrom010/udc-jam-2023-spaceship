using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CryoMaintenanceTask : Interactable
{
    [SerializeField] ParticleSystem particles;

    public AudioClip iceCubeClip;

    public override void Interact(bool primary)
    {
        if(GameManager.instance.spaceShip.cryoManager.GetCryoPercentage() < 100f)
        {
            GameManager.instance.spaceShip.cryoManager.SetCryoPercentage(GameManager.instance.spaceShip.cryoManager.GetCryoPercentage() + 1f);
            particles?.Play();
            AudioSource.PlayClipAtPoint(iceCubeClip, transform.position, 0.5f);
            GameManager.instance.UpdateTerminalUI();
        }
        
    }
}
