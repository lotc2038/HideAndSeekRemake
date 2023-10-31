using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;

    private void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
    }

}
