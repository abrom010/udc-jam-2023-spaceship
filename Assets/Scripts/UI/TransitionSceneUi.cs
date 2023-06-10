using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionSceneUi : MonoBehaviour
{
    public Text CycleValue;
    public Text DistanceValue;

    // Start is called before the first frame update
    void Start()
    {
        CycleValue.text = GameManager.instance.cycle.ToString();
        DistanceValue.text = (GameManager.instance.spaceShip.distanceManager.goalDistance - GameManager.instance.spaceShip.distanceManager.totalDistanceTraveled).ToString();
    }
}
