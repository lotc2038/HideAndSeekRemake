using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;

    [SerializeField]
    private RoomItem _roomItem;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
       foreach (RoomInfo roomInfo in roomList)
        {
            RoomItem item = Instantiate(_roomItem, _content);
            if(item != null)
            {
                item.SetRoomInfo(roomInfo);
            }
        }
    }

    // TODO: Сделать удаление созданных комнат из списка

}
