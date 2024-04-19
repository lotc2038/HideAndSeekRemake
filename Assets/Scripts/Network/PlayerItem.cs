using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    [SerializeField] public TMP_Text text;
    public Player player {  get; private set; }

    public void SetInfo(Player _player)
    {
        player = _player;
        text.text = _player.NickName;
    }
}
