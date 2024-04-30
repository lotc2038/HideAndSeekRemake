using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerSpectator : MonoBehaviour
{
    
    public Camera playerCamera;

    private PhotonView pv;

    private int currentPlayerIndex = 0;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if(!pv.IsMine)
            return;
    }

    private void Update()
    {
        if(!pv.IsMine)
            return;
        // Переключение между игроками с помощью клавиш
        if (Input.GetButtonDown("Fire1"))
        {
            SwitchToNextPlayer();
        }
    }

    private void SwitchToNextPlayer()
    {
        // Получаем текущего игрока
        Player[] players = PhotonNetwork.PlayerList;
        int currentPlayerIndex = Array.IndexOf(players, PhotonNetwork.LocalPlayer);

        // Выбираем следующего игрока
        int nextPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        Player nextPlayer = players[nextPlayerIndex];

        // Переключаемся на камеру следующего игрока
        GameObject nextPlayerGameObject = GameObject.Find(nextPlayer.UserId); // Предполагается, что игроки именованы по никнеймам
        if (nextPlayerGameObject != null)
        {
            Transform playerTransform = nextPlayerGameObject.transform;
            Camera.main.transform.position = playerTransform.position - playerTransform.forward * 15f + Vector3.up * 5f;
            Camera.main.transform.LookAt(playerTransform.position);
        }
    }
  
}
    

