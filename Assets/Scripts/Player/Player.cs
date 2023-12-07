using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks, IDamageable, IShooting, IProp
{
    private PlayerHealth health;
    private Gun gun;
    public Camera playerCamera;

    private void Start()
    {
        health = new PlayerHealth();
        gun = new Gun(GetComponentInChildren<Camera>());
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

    public void Shoot()
    {
        gun.Shoot();
    }

    public void BecomeProp()
    {
        if (Input.GetButtonDown("Fire2"))
        {

        }
    }
}
