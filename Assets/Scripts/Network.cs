using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Network : MonoBehaviour
{
   
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connected to Master");
    }


}
