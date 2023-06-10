using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoSpawner : MonoBehaviour
{
    public int spawnAmount = 4;

    void Start()
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            int childIndex;
            do childIndex = Random.Range(0, transform.childCount);
            while(transform.GetChild(childIndex).gameObject.activeSelf);
            transform.GetChild(childIndex).gameObject.SetActive(true);
        }
    }
}
