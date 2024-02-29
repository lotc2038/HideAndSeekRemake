using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

using Random = UnityEngine.Random;


public class GameManager : MonoBehaviourPunCallbacks
{
    
    public GameObject _playerHunterPrefab;
    public GameObject _playerPropPrefab;

  

    MatchTimer _matchTimer = new MatchTimer();
    bool _matchEnded;
    
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            CreateTeams();
            
        }
        StartMatch();
        SpawnPlayer();
    }

    private void CreateTeams()
    {
        Player[] players = PhotonNetwork.PlayerList;

        
        for(int i = 0; i < players.Length; i++)
        {
            if (i % 2 == 0)
            {
                players[i].JoinTeam(1);
            }
            else
            {
                players[i].JoinTeam(2);
            }
        }
    }


    
    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(_playerHunterPrefab.name, new Vector3(Random.Range(-10f, 10f), 4),
                Quaternion.identity);
    }

    
    private void Update()
    {
        if (!_matchEnded)
        {
            _matchTimer.UpdateTimer();
            
        }
    }


    // Вроде как у фотона есть своя реализация таймера
    private void StartMatch()
    {
        _matchTimer.OnEnded += MatchEnded;
        _matchTimer.StartTimer();
        _matchEnded = false;
        Debug.Log("Timer has started");
    }

    //TODO: Сделать логику завершения матча
    private void MatchEnded()
    {
        Debug.Log("Match ended! (GM)");
        _matchTimer.OnEnded -= MatchEnded;
        _matchEnded = true;
    }
}