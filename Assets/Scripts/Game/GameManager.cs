using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

using Random = UnityEngine.Random;


public class GameManager : MonoBehaviourPunCallbacks
{
    
    public GameObject _playerHunterPrefab;
    public GameObject _playerPropPrefab;

    private MatchTimer _matchTimer = new MatchTimer();
    bool _matchEnded;
    
    private enum MatchPhase
    {
        TeamSelection,
        WarmUp,
        MainMatch
    }
    
    private MatchPhase _currentPhase = MatchPhase.TeamSelection;
    private void Start()
    {
        _matchTimer.OnTimerEnd += OnPhaseEnd;
        _matchTimer.StartTimer(10f);
        Debug.Log("TeamSelect");
        PanelManager.Instance.OpenPanel<TeamSelectionPanel>();
    }

    
    private void OnPhaseEnd()
    {
        switch (_currentPhase)
        {
            case MatchPhase.TeamSelection:
                _currentPhase = MatchPhase.WarmUp;
                Debug.Log("WarmUp");
                _matchTimer.StartTimer(30f);
                break;
            case MatchPhase.WarmUp:
                _currentPhase = MatchPhase.MainMatch;
                _matchTimer.StartTimer(300f);
                Debug.Log("MainMatch");
                break;
            case MatchPhase.MainMatch:
                
                break;
        }
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
        
        Player player = PhotonNetwork.LocalPlayer;

        if (player.GetPhotonTeam().Code == 1)
        {
            PhotonNetwork.Instantiate(_playerHunterPrefab.name, new Vector3(Random.Range(-10f, 10f), 4),
                Quaternion.identity);
            //PanelManager.Instance.OpenPanel<HunterHUD>();
            PanelManager.Instance.OpenPanel<HUD>();
        }

        if (player.GetPhotonTeam().Code == 2)
        {
            PhotonNetwork.Instantiate(_playerPropPrefab.name, new Vector3(Random.Range(-10f, 10f), 4),
                Quaternion.identity);
           // PanelManager.Instance.OpenPanel<PropHUD>();
           PanelManager.Instance.OpenPanel<HUD>();
        }
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
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
  
       
        _matchEnded = false;
        Debug.Log("Timer has started");
    }

    //TODO: Сделать логику завершения матча
    private void MatchEnded()
    {
        Debug.Log("Match ended! (GM)");
        
        _matchEnded = true;
    }
}