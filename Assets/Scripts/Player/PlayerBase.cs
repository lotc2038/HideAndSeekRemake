using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class PlayerBase : MonoBehaviourPunCallbacks
{

    
    public Health health;
    
    //private TextMeshPro NicknameText; 

    
    
    public void Start()
    {
        
        
        //NicknameText.SetText(photonView.Owner.NickName);
    }



    
    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
    
    

}
