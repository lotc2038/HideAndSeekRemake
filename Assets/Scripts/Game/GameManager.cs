using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    MatchTimer _matchTimer = new MatchTimer();

    bool _matchEnded;

    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(-10f, 10f), 2), Quaternion.identity); //TODO:  подправить спавн
        if (PhotonNetwork.IsMasterClient)
        {
            StartMatch();
        }
    }



    private void Update()
    {
        if (!_matchEnded)
        {
            _matchTimer.UpdateTimer();
        }// не самая лучшая идея как мне кажется, может, лучше через корутину?
    }


    public void StartMatch()
    {
        _matchTimer.OnEnded += MatchEnded;
        _matchTimer.StartTimer();
        _matchEnded = false;
        Debug.Log("Timer has started");
    }

    //TODO: Сделать логику завершения матча
    public void MatchEnded()
    {
        Debug.Log("Match ended! (GM)");
        _matchTimer.OnEnded -= MatchEnded;
        _matchEnded = true;
    }

}
