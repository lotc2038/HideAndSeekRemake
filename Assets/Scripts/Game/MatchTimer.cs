using System;
using UnityEngine;
using TMPro;

public class MatchTimer 
{
    private float _startTime;
    private float _matchDuration = 15.0f;

    public event Action OnEnded;

    public void StartTimer()
    {
        _startTime = Time.time;
    }

    public void UpdateTimer()
    {
        float currentTime = Time.time - _startTime;
        float remainingTime = _matchDuration - currentTime;

        if (remainingTime <= 0)
        {
            OnEnded?.Invoke();
        }
    }



}

