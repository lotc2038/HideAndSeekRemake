using System;
using UnityEngine;
using TMPro;

public class MatchTimer 
{
    private float _startTime;
    private float _duration;
    public Action OnTimerEnd;

    public void StartTimer(float duration)
    {
        _duration = duration;
        _startTime = Time.time;
    }

    public void UpdateTimer()
    {
        if (Time.time - _startTime >= _duration)
        {
            OnTimerEnd?.Invoke();
        }
    }



}

