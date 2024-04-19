using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class PlayerBase : MonoBehaviourPunCallbacks, IDamageable
{

    public Health health;

    
    //private TextMeshPro NicknameText; 

    
    
    public void Start()
    {
        health = new Health();
        Debug.Log(health.GetCurrentHealth());
        health.onDeath += Death;
        //NicknameText.SetText(photonView.Owner.NickName);
    }


    
    public void TakeDamage(int damage)
    {
        photonView.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    public void RPC_TakeDamage(int damage)
    {
        if (photonView.IsMine)
        {
            health.TakeDamage(damage);
            HUD.Instance.HealthUpdate(health.GetCurrentHealth());
        }
    }
    
    public void Death()
    {
        photonView.RPC("RPC_Death", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_Death()
    {
        Destroy(this.gameObject);
    }

}
