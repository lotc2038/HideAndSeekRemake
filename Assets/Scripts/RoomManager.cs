using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class RoomManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private TMP_Text roomName;

    public RoomItem roomItemPrefab;

    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform content;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(roomName.text, new RoomOptions() { MaxPlayers = 6 }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
        MenuManager.Instance.OpenMenu("Room");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach(RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, content);
            
        }

    }

}
