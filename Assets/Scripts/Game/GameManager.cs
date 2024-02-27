using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviourPunCallbacks
{
/*
 * TODO: Баг при заходе мастера-клиента на сцену (префаб игрока дублируется), скорее всего связано с особенностью работы фотона, но это не точно
 * Решение 1: Сделать выбор команд до матча, т.е выбирать команду в комнате, после чего уже загружать сцену с игрой и инфой о командах игрока
 * Решение 2: Сделать какую-то задержку (например таймер до начала матча), чтобы все коллбэки успели отработать
 * Решение 3: По сути гибридное решение, сделать выбор команд в сцене с игрой, с помощью какого-то общего префаба игрока и после выбора спавнить нужный (что-то типа спектатора)
 * Решение 4: Сделать метод спавна у игрока и вызывать отсюда по готовности
 */

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