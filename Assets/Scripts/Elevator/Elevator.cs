using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Interactable
{
    [SerializeField] Transform player;
    [SerializeField] Transform[] floors;

    private float desiredDuration = 5f;
    private float elapsedTime;

    private int currentFloor;

    public bool isMoving;
    public bool isGoingUp;

    void Start()
    {
        currentFloor = 1;
        hasSecondaryInteraction = true;
    }

    void Update()
    {
        if(isMoving)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            if(isGoingUp)
            {
                transform.position = Vector3.Lerp(floors[currentFloor].position, floors[currentFloor + 1].position, percentageComplete);
                if(transform.position.y >= floors[currentFloor + 1].position.y)
                {
                    player.parent = null;
                    isMoving = false;
                    elapsedTime = 0;
                    currentFloor++;
                    player.gameObject.GetComponent<Player>().shouldMove = true;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(floors[currentFloor].position, floors[currentFloor - 1].position, percentageComplete);
                if(transform.position.y <= floors[currentFloor - 1].position.y)
                {
                    player.parent = null;
                    isMoving = false;
                    elapsedTime = 0;
                    currentFloor--;
                    player.gameObject.GetComponent<Player>().shouldMove = true;
                }
            }
        }
    }

    public override void Interact(bool primary)
    {
        if(!isMoving)
        {
            if(primary)
            {
                if(currentFloor >= floors.Length) return;
                player.parent = transform;
                player.gameObject.GetComponent<Player>().shouldMove = false;
                isGoingUp = true;
                isMoving = true;
            } 
            else
            {
                if(currentFloor < 0) return;
                player.parent = transform;
                player.gameObject.GetComponent<Player>().shouldMove = false;
                isGoingUp = false;
                isMoving = true;
            }
        }
    }
}
