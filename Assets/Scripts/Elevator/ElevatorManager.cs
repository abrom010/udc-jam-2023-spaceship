using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    [SerializeField] private Vector3 startingPosition;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float speed;

    public bool isMoving;
    public bool isLeaving;

    // make player child of elevator

    void Start()
    {
        transform.position = startingPosition;
    }

    void Update()
    {
        if(isMoving)
        {
            if(isLeaving)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
                if(transform.position.y >= targetPosition.y - 0.25f)
                {
                    isMoving = false;
                    transform.position = new Vector3(transform.position.x, targetPosition.y, transform.position.z);
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, startingPosition, speed * Time.deltaTime);
                if(transform.position.y <= startingPosition.y + 0.25f)
                {
                    isMoving = false;
                    transform.position = new Vector3(transform.position.x, startingPosition.y, transform.position.z);
                }
            }
        }
    }


}
