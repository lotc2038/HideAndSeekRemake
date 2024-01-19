using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProp : PlayerBase, IDamageable
{

    public PropGun gun;

    private void Start()
    {
        gun = GetComponentInChildren<PropGun>();
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot();
        }


    }
    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }

    public void ChangeToProp()
    {

    }

}
