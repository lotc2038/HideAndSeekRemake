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
            
            
        }
        StartMatch();
      //  SpawnPlayer();
    }

    private void OnEnable()
    {
        PhotonTeamsManager.PlayerJoinedTeam += OnPlayerJoinedTeam;
        PhotonTeamsManager.PlayerLeftTeam += OnPlayerLeftTeam;
    }
    
    

    private void OnPlayerJoinedTeam(Player player, PhotonTeam team)
    {
        Debug.LogFormat("Player {0} joined team {1}", player, team);
        SpawnPlayer();
    }
    
    private void OnPlayerLeftTeam(Player player, PhotonTeam team)
    {
        Debug.LogFormat("Player {0} left team {1}", player, team);
    }
    
    private void SpawnPlayer()
    {
        //можно onplayerjoinedteam вызывать метод спавна
        
        Player player = PhotonNetwork.LocalPlayer;

        if (player.GetPhotonTeam().Code == 1)
        {

            PhotonNetwork.Instantiate(_playerHunterPrefab.name, new Vector3(Random.Range(-10f, 10f), 4),
                Quaternion.identity);
        }

        if (player.GetPhotonTeam().Code == 2)
        {
            PhotonNetwork.Instantiate(_playerPropPrefab.name, new Vector3(Random.Range(-10f, 10f), 4),
                Quaternion.identity);
        }
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