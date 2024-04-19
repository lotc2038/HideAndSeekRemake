using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class HUD : PanelBase
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;
    
    public static HUD Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    //костыльное решение, но пока сойдет
    private void Start()
    {
        Player player = PhotonNetwork.LocalPlayer;
        if (player.GetPhotonTeam().Code == 1)
        {
            ammoText.gameObject.SetActive(true);
        }
        else
        {
            ammoText.gameObject.SetActive(false);
        }
    }
    
    public void HealthUpdate(int health)
    {
        healthText.text = health.ToString();
    }

    public void AmmoUpdate(int ammo)
    {
        ammoText.text = ammo.ToString();
    }
    
}
