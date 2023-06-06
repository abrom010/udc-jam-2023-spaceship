using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private enum State { Playing, Won, Lost };
    State state = State.Playing;

    public SpaceShip spaceShip;
    public CountdownTimer timer;

    private int cycle = 0;
    private int maxCycles = 100;

    private void Awake()
    {
        timer.SetStartTime(5f);
    }

    private void Start()
    {
        spaceShip = new SpaceShip();
        ResumeActiveCycle();
    }

    private void Update()
    {
        if(timer.DidTimerHitZero())
        {
            EndActiveCycle();
        }
    }

    private void EndActiveCycle()
    {
        PauseActiveCycle();
        ProcessCycle();
        ResumeActiveCycle();
    }

    private void PauseActiveCycle()
    {
        timer.Stop();
    }

    private void ResumeActiveCycle()
    {
        timer.Resume();
    }

    private void EndGame()
    {
        int score = CalculateScore();
        Debug.Log("You " + (state == State.Won ? "won!" : "lost!"));
        Debug.Log("Cycles: " + cycle);
        Debug.Log("Survivors Left: " + spaceShip.survivorManager.GetSurvivorCount());
        Debug.Log("Your score: " + score);
    }

    private int CalculateScore()
    {
        int score = 0;
        score += maxCycles - cycle;
        score *= Mathf.RoundToInt(Mathf.Pow(spaceShip.survivorManager.GetSurvivorCount(), 2));
        return score;
    }

    private void ProcessCycle()
    {
        cycle++;
        spaceShip.survivorManager.ComputeSurvivorsForCycle(spaceShip.cryoManager.GetCryoPercentage());
        spaceShip.distanceManager.ComputeDistanceForCycle(spaceShip.fuelManager.GetFuelPercentage());
        spaceShip.cryoManager.SetCryoPercentage(25f);
        spaceShip.fuelManager.SetFuelPercentage(35f);
        timer.WindUp();
        Debug.Log("Time ran out. Cycle #" + cycle + " is starting");
        Debug.Log("Cycles: " + cycle);
        Debug.Log("Survivors Left: " + spaceShip.survivorManager.GetSurvivorCount());
    }
    
}
