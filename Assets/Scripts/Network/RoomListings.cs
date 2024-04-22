using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListings : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;

    [SerializeField]
    private RoomItem _roomItem;

    private List<RoomInfo> _roomCachedListings = new List<RoomInfo>();
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var room in roomList)
        {
            int index = _roomCachedListings.FindIndex(x => x.Name == room.Name);

            if (index == -1 && !room.RemovedFromList)
            {
                _roomCachedListings.Add(room);
            }
            else if (index != -1 && room.RemovedFromList)
            {
                _roomCachedListings.RemoveAt(index);
            }
            else if (index != -1)
            {
                _roomCachedListings[index] = room;
            }
        }

        UpdateList();
    }
    

    private void UpdateList()
    {
        foreach (Transform roomItem in _content)
        {
            Destroy(roomItem.gameObject);
        }

        foreach (RoomInfo room in _roomCachedListings)
        {
            RoomItem item = Instantiate(_roomItem, _content);
            item.SetRoomInfo(room);
        }
        
    }
    

}
