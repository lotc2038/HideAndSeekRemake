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
        // ������������ ����� �������� � ������� ������
        if (Input.GetButtonDown("Fire1"))
        {
            SwitchToNextPlayer();
        }
    }

    private void SwitchToNextPlayer()
    {
        // �������� �������� ������
        Player[] players = PhotonNetwork.PlayerList;
        int currentPlayerIndex = Array.IndexOf(players, PhotonNetwork.LocalPlayer);

        // �������� ���������� ������
        int nextPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        Player nextPlayer = players[nextPlayerIndex];

        // ������������� �� ������ ���������� ������
        GameObject nextPlayerGameObject = GameObject.Find(nextPlayer.UserId); // ��������������, ��� ������ ��������� �� ���������
        if (nextPlayerGameObject != null)
        {
            Transform playerTransform = nextPlayerGameObject.transform;
            Camera.main.transform.position = playerTransform.position - playerTransform.forward * 15f + Vector3.up * 5f;
            Camera.main.transform.LookAt(playerTransform.position);
        }
    }
  
}
    

