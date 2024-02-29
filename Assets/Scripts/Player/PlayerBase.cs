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
    public TextMeshProUGUI healthText;
    
    //private TextMeshPro NicknameText; 

    
    
    public void Start()
    {
        
        Debug.Log(health.GetCurrentHealth());
        healthText.text = health.GetCurrentHealth().ToString();
        //NicknameText.SetText(photonView.Owner.NickName);
    }



    
    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
    
    

}
