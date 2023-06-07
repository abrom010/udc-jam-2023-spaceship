using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillTask : Interactable
{
    public bool isExercising;

    [SerializeField] private Transform treadmillFront;
    [SerializeField] private Transform treadmillBack;

    private Vector3 treadmillDirection;

    private void Start()
    {
        hasSecondaryInteraction = true;
        treadmillDirection = (treadmillFront.position - treadmillBack.position).normalized;
    }

    private void Update()
    {
        if(isExercising)
        {
            if(Input.GetKey(KeyCode.W))
            {
                GameManager.instance.player.transform.position += treadmillDirection * Time.deltaTime;
                GameManager.instance.player.SetFitness(GameManager.instance.player.GetFitness() + Time.deltaTime);
            }
            else
            {
                GameManager.instance.player.transform.position -= treadmillDirection * Time.deltaTime;
            }

            // player falls off treadmill
            if((Vector3.Distance(GameManager.instance.player.transform.position, transform.position) >= Vector3.Distance(treadmillFront.position, transform.position))
                || (Vector3.Distance(GameManager.instance.player.transform.position, transform.position) >= Vector3.Distance(treadmillBack.position, transform.position)))
            {
                StopExercising();
            }
        }
    }

    public override void Interact(bool primary)
    {
        if(primary)
        {
            if(!isExercising)
            {
                StartExcercising();
            }
        }
        else
        {
            if(isExercising)
            {
                StopExercising();
            }
        }
    }

    private void StartExcercising()
    {
        GameManager.instance.player.shouldMove = false;
        GameManager.instance.player.transform.position = new Vector3(transform.position.x, GameManager.instance.player.transform.position.y, transform.position.z);
        isExercising = true;
    }

    private void StopExercising()
    {
        isExercising = false;
        GameManager.instance.player.transform.position = new Vector3(treadmillBack.position.x, treadmillBack.position.y, treadmillBack.position.z - 5f);
        GameManager.instance.player.shouldMove = true;
        
    }
}
