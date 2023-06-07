using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TreadmillTask : Interactable
{
    private bool isExercising;

    [SerializeField] private Transform treadmillFront;
    [SerializeField] private Transform treadmillBack;

    private void Start()
    {
        hasSecondaryInteraction = true;
    }

    private void Update()
    {
        if(isExercising)
        {
            Player player = gameManager.GetComponent<Player>();
            if(Input.GetKeyDown(KeyCode.W))
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + Time.deltaTime);
                player.SetFitness(player.GetFitness() + Time.deltaTime);
            }
            else
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + Time.deltaTime);
            }

            // player falls off treadmill
            if(player.transform.position.z > treadmillFront.position.z || player.transform.position.z < treadmillBack.position.z)
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
        Player player = gameManager.GetComponent<Player>();
        isExercising = true;
        player.shouldMove = false;
        player.transform.position = transform.position;
    }

    private void StopExercising()
    {
        Player player = gameManager.GetComponent<Player>();
        isExercising = false;
        player.shouldMove = true;
        player.transform.position = new Vector3(treadmillBack.position.x, treadmillBack.position.y, treadmillBack.position.z + 5f);
    }
}
