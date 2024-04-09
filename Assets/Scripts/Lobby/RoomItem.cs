using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : PanelBase
{

    [SerializeField] private Button _joinButton;
    [SerializeField] public TMP_Text _text;

    public RoomInfo RoomInfo {  get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;    
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

    protected override void OnOpened()
    {
        _joinButton.onClick.AddListener(OnJoinButtonClick);
    }

    private void OnJoinButtonClick()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
        PanelManager.Instance.OpenPanel<Room>();
    }

    protected override void OnClosed()
    {
        _joinButton.onClick.RemoveListener(OnJoinButtonClick);
    }
}
