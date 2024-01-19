using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerBase : MonoBehaviourPunCallbacks
{
    public Health health;

    public void Start()
    {
        health = new Health();
    }


    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }

}
