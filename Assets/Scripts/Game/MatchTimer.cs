using UnityEngine;


public class MatchTimer 
{
    private float startTime;
    private float matchDuration = 30.0f;
    public bool isMatchEnded; // �����, ����� ������� ��� � ���� ����������?

    public void StartTimer()
    {
        startTime = Time.time;
    }

    //TODO: ������� ������ ���������� �����

    public void UpdateTimer()
    {
        if (isMatchEnded == true)
        { return; }

        float currentTime = Time.time - startTime;
        float remainingTime = matchDuration - currentTime;

        if (remainingTime > 0)
        {
        }
        else
        {
            Debug.Log("Time is over!");
            isMatchEnded = true;
        }
    }
}

