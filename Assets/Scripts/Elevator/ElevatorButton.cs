using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : Interactable
{
    [SerializeField] ElevatorManager elevatorManager;

    public override void Interact()
    {
        if(!elevatorManager.isMoving)
        {
            elevatorManager.isLeaving = !elevatorManager.isLeaving;
            elevatorManager.isMoving = true;
        }
    }
}
