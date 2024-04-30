using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

using Random = UnityEngine.Random;


public class GameManager : MonoBehaviourPunCallbacks
{
   [SerializeField] private GameObject _playerHunterPrefab;
   [SerializeField] private GameObject _playerPropPrefab;

    private MatchTimer _matchTimer = new MatchTimer();
    private MatchPhase _currentPhase = MatchPhase.TeamSelection;
    private bool _matchEnded;

    public static List<Player> _teamHunters = new List<Player>();
    public static List<Player> _teamProps = new List<Player>();
    
    
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
               // StartCoroutine(ShowBlackscreen());
                _matchTimer.StartTimer(30f);
                break;
            case MatchPhase.WarmUp:
                _currentPhase = MatchPhase.MainMatch;
                _matchTimer.StartTimer(300f);
                Debug.Log("MainMatch");
                break;
            case MatchPhase.MainMatch:
                //вывод скорборда
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
        //можно просто отправлять сюда номер команды и спавнить, зачем еще раз получать   
        Player player = PhotonNetwork.LocalPlayer;

        if (player.GetPhotonTeam().Code == 1)
        {
            PhotonNetwork.Instantiate(_playerHunterPrefab.name, new Vector3(Random.Range(5, 15f), 4,7),
                Quaternion.identity);
            _teamHunters.Add(player);
            player.TagObject = this.gameObject;
            PanelManager.Instance.OpenPanel<HUD>();
        }

        if (player.GetPhotonTeam().Code == 2)
        {
            PhotonNetwork.Instantiate(_playerPropPrefab.name, new Vector3(Random.Range(5, 15f), 4, 7),
                Quaternion.identity);
            _teamProps.Add(player);
            player.TagObject = this.gameObject;
           PanelManager.Instance.OpenPanel<HUD>();
        }
        
    }

    
    private void Update()
    {
        if (!_matchEnded)
        {
            _matchTimer.UpdateTimer();
        }
    }


    public IEnumerator ShowBlackscreen()
    {
        foreach (var player in _teamHunters)
        {
            PanelManager.Instance.OpenPanel<Blackscreen>();
        }
        yield return new WaitForSeconds(30f);
    }
  
    
    
}