using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class PlayerBase : MonoBehaviourPunCallbacks, IDamageable
{

    public Health health = new Health();
    public GameObject Spec;
    
    //private TextMeshPro NicknameText; 

    //TODO: Нужно сделать сеттер для изменения скорости игрока
    
    public void Awake()
    {
        //health = new Health();
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
        PhotonNetwork.Instantiate(Spec.name, gameObject.transform.position, Quaternion.identity);
    }

    [PunRPC]
    public void RPC_Death()
    { 
        gameObject.SetActive(false);
       // PhotonNetwork.Instantiate(Spec.name, gameObject.transform.position, Quaternion.identity);
    }

}
