using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerListings : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;

    [SerializeField]
    private PlayerItem _playerItem;

    private List<PlayerItem> _playerListigs = new List<PlayerItem>();
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        _playerItem.SetInfo(newPlayer);
        Instantiate(_playerItem, _content);
        _playerListigs.Add(_playerItem);
        UpdateList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _playerListigs.FindIndex(x => x.player.NickName == otherPlayer.NickName);

        if (index != -1)
        {
            _playerListigs.RemoveAt(index);
        }
        
        UpdateList();
    }


    public override void OnJoinedRoom()
    {
       UpdateList();
    }
    
   private void UpdateList()
    {
        foreach (Transform playerItem in _content)
        {
            Destroy(playerItem.gameObject);
        }

        foreach (var player in PhotonNetwork.PlayerList)
        {
            _playerItem.SetInfo(player);
            Instantiate(_playerItem, _content);
        }
    }
  
    
}
