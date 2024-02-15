using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerBase : MonoBehaviourPunCallbacks
{
    public Health health;
    //private TextMeshPro NicknameText; 
    // PlayerCustom...Team???
    public void Start()
    {
        health = new Health();
        //NicknameText.SetText(photonView.Owner.NickName);
    }


    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }

}
