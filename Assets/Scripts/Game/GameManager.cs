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
<<<<<<< HEAD
        PanelManager.Instance.OpenPanel<TeamSelectionPanel>();
        StartMatch();
    }

    private void OnEnable()
    {
        PhotonTeamsManager.PlayerJoinedTeam += OnPlayerJoinedTeam;
        PhotonTeamsManager.PlayerLeftTeam += OnPlayerLeftTeam;
    }
    
    

    private void OnPlayerJoinedTeam(Player player, PhotonTeam team)
    {
        if (player.IsLocal)
        {
            Debug.LogFormat("Player {0} joined team {1}", player, team);
            SpawnPlayer();
        }
    }
    
    private void OnPlayerLeftTeam(Player player, PhotonTeam team)
    {
        Debug.LogFormat("Player {0} left team {1}", player, team);
    }
    
    private void SpawnPlayer()
    {
=======
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
>>>>>>> e25b2fa0c486a026b983f6ebacc7fad5e109cfa7
        
        Player player = PhotonNetwork.LocalPlayer;

        if (player.GetPhotonTeam().Code == 1)
        {
<<<<<<< HEAD
            PhotonNetwork.Instantiate(_playerHunterPrefab.name, new Vector3(Random.Range(-10f, 10f), 4),
                Quaternion.identity);
            PanelManager.Instance.OpenPanel<HunterHUD>();
=======

            PhotonNetwork.Instantiate(_playerHunterPrefab.name, new Vector3(Random.Range(-10f, 10f), 4),
                Quaternion.identity);
>>>>>>> e25b2fa0c486a026b983f6ebacc7fad5e109cfa7
        }

        if (player.GetPhotonTeam().Code == 2)
        {
            PhotonNetwork.Instantiate(_playerPropPrefab.name, new Vector3(Random.Range(-10f, 10f), 4),
                Quaternion.identity);
<<<<<<< HEAD
            PanelManager.Instance.OpenPanel<PropHUD>();
        }
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
=======
        }
>>>>>>> e25b2fa0c486a026b983f6ebacc7fad5e109cfa7
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