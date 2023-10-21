using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _text;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

    

}
