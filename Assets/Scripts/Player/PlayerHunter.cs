using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHunter : PlayerBase
{
    public Gun gun;

    private void Start()
    {
        gun = GetComponentInChildren<Gun>();  
    }

    private void Update()
    {
        if (!photonView.IsMine) 
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.Reload();
        }

    }


}
