using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCollision : MonoBehaviour
{
    public ParticleSystem vfx;
    public AudioSource audioSource;


    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        vfx.Play();
    }
}
