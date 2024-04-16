using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerHunter : MonoBehaviourPunCallbacks
{
    public List<Gun> guns;
    public int currentWeaponIndex = 0;
    private void Start()
    {
        SwitchWeapon(0);
    }

    private void Update()
    {
        if (!photonView.IsMine) 
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            guns[currentWeaponIndex].Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            guns[currentWeaponIndex].Reload();
        }
        //подумать над этими else if
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            photonView.RPC("SwitchWeapon", RpcTarget.All, 0);
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && guns.Count >= 2)
        {
            photonView.RPC("SwitchWeapon", RpcTarget.All, 1);
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && guns.Count >= 2)
        {
            photonView.RPC("SwitchWeapon", RpcTarget.All, 2);
            SwitchWeapon(2);
        }

    }
    
    [PunRPC]
    private void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < guns.Count && weaponIndex != currentWeaponIndex)
        {
            guns[currentWeaponIndex].gameObject.SetActive(false);
            currentWeaponIndex = weaponIndex;
            guns[currentWeaponIndex].gameObject.SetActive(true);
        }
    }

    private void TakeProp()
    {
        
    }
    
}
