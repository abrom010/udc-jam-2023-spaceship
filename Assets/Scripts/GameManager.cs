using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private enum State { Playing, Won, Lost };
    State state = State.Playing;

    public SpaceShip spaceShip;
    

    private int cycle = 0;
    private int maxCycles = 100;

    public CountdownTimer timer;
    public Player player;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        spaceShip = new SpaceShip();
        OnLoadTimer();
    }

    public void OnLoadTimer()
    {
        timer.SetStartTime(120f);
        timer.ResetAll();
        timer.Resume();
    }

    private void Update()
    {
        if(timer != null)
        {
            if(timer.DidTimerHitZero())
            {
                EndActiveCycle();
            }
        }
        
    }

    private void EndActiveCycle()
    {
        PauseActiveCycle();
        ProcessCycle();
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
        Debug.Log("Time ran out. Cycle #" + cycle + " is starting");
        Debug.Log("Cycles: " + cycle);
        Debug.Log("Survivors Left: " + spaceShip.survivorManager.GetSurvivorCount());
        timer = null;
        player = null;
        SceneManager.LoadScene("TransitionScene");
    }
    
}
