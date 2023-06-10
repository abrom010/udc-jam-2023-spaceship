using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Interactable
{
    // work on doors open/close

    [SerializeField] Transform player;
    [SerializeField] Transform[] floors;

    private float desiredDuration = 5f;
    private float elapsedTime;

    private int currentFloor;

    public bool isMoving;
    public bool isGoingUp;

    bool frontDoorClosed;
    bool backDoorClosed;

    [SerializeField] Transform frontDoor1;
    [SerializeField] Transform frontDoor2;
    [SerializeField] Transform backDoor1;
    [SerializeField] Transform backDoor2;

    [SerializeField] AudioClip elevatorDingClip;
    [SerializeField] AudioClip elevatorTravelClip;

    void Start()
    {
        etext = "up";
        qtext = "down";
        currentFloor = 1;
        hasSecondaryInteraction = true;

        frontDoorClosed = true;
        backDoorClosed = true;
        OpenFrontDoor();
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
                    AudioSource.PlayClipAtPoint(elevatorDingClip, transform.position, 0.5f);
                    GameManager.instance.player.isStationary = false;
                    player.parent = null;
                    isMoving = false;
                    elapsedTime = 0;
                    currentFloor++;
                    player.gameObject.GetComponent<Player>().shouldMove = true;
                    if(currentFloor == 1)
                    {
                        OpenFrontDoor();
                    }
                    else
                    {
                        OpenBackDoor();
                    }
                    
                }
            }
            else
            {
                transform.position = Vector3.Lerp(floors[currentFloor].position, floors[currentFloor - 1].position, percentageComplete);
                if(transform.position.y <= floors[currentFloor - 1].position.y)
                {
                    AudioSource.PlayClipAtPoint(elevatorDingClip, transform.position, 0.5f);
                    GameManager.instance.player.isStationary = false;
                    player.parent = null;
                    isMoving = false;
                    elapsedTime = 0;
                    currentFloor--;
                    player.gameObject.GetComponent<Player>().shouldMove = true;
                    if(currentFloor == 1)
                    {
                        OpenFrontDoor();
                    } 
                    else
                    {
                        OpenBackDoor();
                    }
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
                if(currentFloor >= floors.Length - 1) return;
                AudioSource.PlayClipAtPoint(elevatorTravelClip, transform.position, 0.4f);
                GameManager.instance.player.isStationary = true;
                player.parent = transform;
                player.gameObject.GetComponent<Player>().shouldMove = false;
                isGoingUp = true;
                isMoving = true;
                CloseFrontDoor();
                CloseBackDoor();
            } 
            else
            {
                if(currentFloor <= 0) return;
                AudioSource.PlayClipAtPoint(elevatorTravelClip, transform.position, 0.4f);
                GameManager.instance.player.isStationary = true;
                player.parent = transform;
                player.gameObject.GetComponent<Player>().shouldMove = false;
                isGoingUp = false;
                isMoving = true;
                CloseFrontDoor();
                CloseBackDoor();
            }
        }
    }

    private void OpenFrontDoor()
    {
        if(!frontDoorClosed) return;
        frontDoorClosed = false;
        Vector3 firstDoorPos = frontDoor1.position;
        Vector3 secondDoorPos = frontDoor2.position;
        frontDoor1.position = new Vector3(firstDoorPos.x - 3f, firstDoorPos.y, firstDoorPos.z);
        frontDoor2.position = new Vector3(secondDoorPos.x + 3f, secondDoorPos.y, secondDoorPos.z);
    }
    private void CloseFrontDoor()
    {
        if(frontDoorClosed) return;
        frontDoorClosed = true;
        Vector3 firstDoorPos = frontDoor1.position;
        Vector3 secondDoorPos = frontDoor2.position;
        frontDoor1.position = new Vector3(firstDoorPos.x + 3f, firstDoorPos.y, firstDoorPos.z);
        frontDoor2.position = new Vector3(secondDoorPos.x - 3f, secondDoorPos.y, secondDoorPos.z);
    }

    private void OpenBackDoor()
    {
        if(!backDoorClosed) return;
        backDoorClosed = false;
        Vector3 firstDoorPos = backDoor1.position;
        Vector3 secondDoorPos = backDoor2.position;
        backDoor1.position = new Vector3(firstDoorPos.x - 3f, firstDoorPos.y, firstDoorPos.z);
        backDoor2.position = new Vector3(secondDoorPos.x + 3f, secondDoorPos.y, secondDoorPos.z);
    }
    private void CloseBackDoor()
    {
        if(backDoorClosed) return;
        backDoorClosed = true;
        Vector3 firstDoorPos = backDoor1.position;
        Vector3 secondDoorPos = backDoor2.position;
        backDoor1.position = new Vector3(firstDoorPos.x + 3f, firstDoorPos.y, firstDoorPos.z);
        backDoor2.position = new Vector3(secondDoorPos.x - 3f, secondDoorPos.y, secondDoorPos.z);
    }
    
}
