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

    //TODO: Сделать удаление игроков из списка при выходе, добавить игрока-хоста в список игроков
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerItem playerItem = Instantiate(_playerItem, _content);

        if (playerItem != null)
        {
            _playerItem.SetInfo(newPlayer);
            _playerListigs.Add(playerItem);
        }
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _playerListigs.FindIndex(x => x.player == otherPlayer);

        if (index != -1)
        {
            Destroy(_playerListigs[index].gameObject);
            _playerListigs.RemoveAt(index);
        }
    }

    public override void OnLeftRoom()
    {
       
    }
  
    
}
