using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private float countdown;
    private bool isRunning;
    private bool hitZero;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        countdown = startTime;
        isRunning = false;
        hitZero = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning)
        {
            countdown -= Time.deltaTime;
        }

        if(countdown <= 0)
        {
            Stop();
            countdown = 0;
            hitZero = true;
        }
    }

    public void SetStartTime(float time)
    {
        startTime = time;
    }

    public void Stop()
    {
        isRunning = false;
    }

    public void Resume()
    {
        isRunning = true;
    }

    public void WindUp()
    {
        countdown = startTime;
        hitZero = false;
    }

    public bool DidTimerHitZero()
    {
        return hitZero;
    }
}
