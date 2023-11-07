using System;
using UnityEngine;


public class MatchTimer 
{
    private float startTime;
    private float matchDuration = 15.0f;

    public event Action onEnded;

    public void StartTimer()
    {
        startTime = Time.time;
    }

    public void UpdateTimer()
    {
        float currentTime = Time.time - startTime;
        float remainingTime = matchDuration - currentTime;

        if (remainingTime <= 0)
        {
            Debug.Log("Time is over! (MT)");
            onEnded?.Invoke();
        }
    }



}

