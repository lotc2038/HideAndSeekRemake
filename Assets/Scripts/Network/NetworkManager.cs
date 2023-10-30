using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public TMP_Text roomName;

    void Start()
    {
        Debug.Log("Connecting to Master Server...");
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = "Player " + Random.Range(1000, 9999);
        PhotonNetwork.AutomaticallySyncScene = true;

    }



    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Test");
    }


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }



    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server");
        PhotonNetwork.JoinLobby();
    }



    public override void OnCreatedRoom()
    {
        Debug.Log("Room has been created");
    }



    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Leaved room");
    }

}
