using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    MatchTimer matchTimer = new MatchTimer();

    private void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity); //TODO:  подправить спавн
        if (PhotonNetwork.IsMasterClient)
        {
            matchTimer.StartTimer();
            Debug.Log("Timer has started");
        }
    }

    private void Update()
    {
        matchTimer.UpdateTimer(); // не самая лучшая идея как мне кажется, может, лучше через корутину?
    }

}
