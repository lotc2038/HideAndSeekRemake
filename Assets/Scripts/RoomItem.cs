using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class RoomItem : MonoBehaviourPunCallbacks
{
    public GameObject RoomPrefab;
    public string RoomName { get; private set; }



    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

}
