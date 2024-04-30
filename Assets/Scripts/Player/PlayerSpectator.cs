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
        
     
    }
  
}
    

