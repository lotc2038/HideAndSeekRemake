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
        // health.TakeDamage(damage);
        photonView.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    public void RPC_TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
    
    public void Death()
    {
        Destroy(this.gameObject);
    }
    

}
