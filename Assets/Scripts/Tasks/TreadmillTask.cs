using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillTask : Interactable
{
    public bool isExercising;

    [SerializeField] private Transform treadmillFront;
    [SerializeField] private Transform treadmillMiddle;
    [SerializeField] private Transform treadmillBack;

    private Vector3 treadmillDirection;

    private AudioSource audioSource;

    [SerializeField] private float exerciseRate = 8f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasSecondaryInteraction = true;
        treadmillDirection = (treadmillFront.position - treadmillBack.position).normalized;
    }

    private void Update()
    {
        if(isExercising)
        {
            if(Input.GetKey(KeyCode.W))
            {
                GameManager.instance.player.animator.speed = 3f;
                GameManager.instance.player.transform.position += treadmillDirection * Time.deltaTime * 2f;
                GameManager.instance.player.SetFitness(GameManager.instance.player.GetFitness() >= 100f ? 100f : GameManager.instance.player.GetFitness() + Time.deltaTime * exerciseRate);
            }
            else
            {
                GameManager.instance.player.animator.speed = 1.5f;
                GameManager.instance.player.transform.position -= treadmillDirection * Time.deltaTime;
                GameManager.instance.player.SetFitness(GameManager.instance.player.GetFitness() >= 100f ? 100f : GameManager.instance.player.GetFitness() + Time.deltaTime * 5f);
            }

            // player falls off treadmill
            if(Vector3.Distance(GameManager.instance.player.transform.position, treadmillMiddle.position) >= Vector3.Distance(treadmillFront.position, treadmillMiddle.position))
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
        GameManager.instance.player.gameObject.transform.position = treadmillMiddle.position;
        GameManager.instance.player.gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z));
        isExercising = true;
        audioSource.Play();
    }

    private void StopExercising()
    {
        GameManager.instance.player.animator.speed = 1f;
        isExercising = false;
        GameManager.instance.player.shouldMove = true;
        audioSource.Stop();
    }
}
