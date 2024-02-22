using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{

    [SerializeField]
    public TMP_Text _text;

    public RoomInfo RoomInfo {  get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;    
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

    public void OnClick()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
        MenuManager.Instance.OpenMenu("Room");
    }




}
