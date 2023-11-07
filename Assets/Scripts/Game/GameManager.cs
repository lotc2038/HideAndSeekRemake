using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    MatchTimer matchTimer = new MatchTimer();

    bool matchEnded;

    private void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity); //TODO:  подправить спавн
        if (PhotonNetwork.IsMasterClient)
        {
            StartMatch();
        }
    }



    private void Update()
    {
        if (!matchEnded)
        {
            matchTimer.UpdateTimer();
        }// не самая лучшая идея как мне кажется, может, лучше через корутину?
    }


    public void StartMatch()
    {
        matchTimer.onEnded += MatchEnded;
        matchTimer.StartTimer();
        matchEnded = false;
        Debug.Log("Timer has started");
    }

    //TODO: Сделать логику завершения матча
    public void MatchEnded()
    {
        Debug.Log("Match ended! (GM)");
        matchTimer.onEnded -= MatchEnded;
        matchEnded = true;
    }

}
