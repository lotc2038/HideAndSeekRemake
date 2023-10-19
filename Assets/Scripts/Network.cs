using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Network : MonoBehaviourPunCallbacks
{

    void Start()
    {
        Debug.Log("Connecting to Master Server");
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server");
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("test");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
    }


}
