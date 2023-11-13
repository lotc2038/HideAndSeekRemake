using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks, IDamageable
{

    public int maxHealth = 100;
    private int currentHealth;
    private int range = 100;
    public Camera cameraHolder;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [PunRPC]
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{currentHealth}");
        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
        }

    }

    [PunRPC]
    public void Shoot()
    {
        Ray ray = cameraHolder.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, range))
        {
            PhotonView target = hitInfo.transform.GetComponent<PhotonView>();

            if (target != null)
            {
                IDamageable targetHealth = hitInfo.transform.GetComponent<IDamageable>();

                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(10);
                }
            }
        }
    }

    
    public void TurnToItem()
    {

    }

}
