using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;
using System.Data;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private enum State { Playing, Won, Lost };
    State state = State.Playing;

    public SpaceShip spaceShip;
    

    public int cycle = 1;
    private int maxCycles = 100;

    public CountdownTimer timer;
    public Player player;

    Image fitnessBar;
    Text survivorText;
    Text cryoText;
    Text fuelText;
    Text timerText;
    Text cycleText;
    Text distanceText;

    [SerializeField] private float cycleTime;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            cycle = 1;
        } else if(instance != this)
        {
            Destroy(gameObject);
            return;
        }

        spaceShip = new SpaceShip();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnLoadTimer()
    {
        fitnessBar = GameObject.Find("Image Fitness Bar").GetComponent<Image>();
        survivorText = GameObject.Find("Text Value Survivors").GetComponent<Text>();
        cryoText = GameObject.Find("Text Value Cryo").GetComponent<Text>();
        fuelText = GameObject.Find("Text Value Fuel").GetComponent<Text>();
        timerText = GameObject.Find("Text Value Timer").GetComponent<Text>();
        cycleText = GameObject.Find("Text Value Cycle").GetComponent<Text>();
        distanceText = GameObject.Find("Text Value Distance").GetComponent<Text>();

        spaceShip.cryoManager.ComputeCycleCryoPercentage();
        spaceShip.fuelManager.ComputeCycleFuelPercentage();

        UpdateTerminalUI();

        timer.SetStartTime(cycleTime);
        timer.ResetAll();
        timer.Resume();
    }

    public void UpdateTerminalUI()
    {
        survivorText.text = spaceShip.survivorManager.GetSurvivorCount().ToString();
        cryoText.text = spaceShip.cryoManager.GetCryoPercentage().ToString();
        fuelText.text = spaceShip.fuelManager.GetFuelPercentage().ToString();
        cycleText.text = cycle.ToString();
        distanceText.text = (spaceShip.distanceManager.goalDistance - spaceShip.distanceManager.totalDistanceTraveled).ToString();
    }

    private void Update()
    {
        if(timer != null)
        {
            if(timer.DidTimerHitZero())
            {
                EndActiveCycle();
                return;
            }

            TimeSpan timeSpan = TimeSpan.FromSeconds(timer.GetTime());
            timerText.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);

            if(player != null)
            {
                fitnessBar.fillAmount = player.GetFitness() / 100f;
                if(player.GetFitness() <= 0)
                {
                    EndActiveCycle();
                    return;
                }
            }
            
        }
    }

    public void EndActiveCycle()
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
        SceneManager.LoadScene("GameOverScene");
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
        if(spaceShip.survivorManager.GetSurvivorCount() <= 0)
        {
            SceneManager.LoadScene("Defeat_Survivors");
            return;
        }

        spaceShip.distanceManager.ComputeDistanceForCycle(spaceShip.fuelManager.ComputeCycleFuelPercentage());
        if(spaceShip.distanceManager.totalDistanceTraveled >= spaceShip.distanceManager.goalDistance)
        {
            SceneManager.LoadScene("Gameover");
            return;
        }

        Debug.Log(spaceShip.fuelManager.GetFuelPercentage());
        if(spaceShip.fuelManager.GetFuelPercentage() <= 0)
        {
            SceneManager.LoadScene("Defeat_Fuel");
            return;
        }
        spaceShip.cryoManager.ComputeCycleCryoPercentage();

        Destroy(timer.gameObject);
        Destroy(player.gameObject);
        timer = null;
        player = null;

        SceneManager.LoadScene("TransitionScene_B");
    }
    
}
