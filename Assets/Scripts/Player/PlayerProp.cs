using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerProp : PlayerBase, IDamageable
{

    // TODO: Баг при превращении в предмет у другого игрока вызывает исключение collisionmeshdata couldn't be created, скорее всего нельзя передавать меш и прочее, но можно подкрутить модельку
    
    public float range = 100f;
    public MeshFilter   newMeshFilter;
    public MeshRenderer newMeshRenderer;
    public MeshCollider newMeshCollider;

    private void Start()
    {
        health = new Health();
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            ChangeToProp();
            photonView.RPC("ChangeToProp", RpcTarget.All);
        }


    }
    


    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }

    [PunRPC]
    public void ChangeToProp()
         {
             var direction = transform.forward;
             var ray = new Ray(transform.position, direction);
     
             if (Physics.Raycast(ray, out var hitInfo, range))
             {
                 var hitProp = hitInfo.collider.GetComponent<Prop>();
                 if (hitProp != null)
                 {
                     UpdateProp(hitProp);
                     photonView.RPC("UpdateProp", RpcTarget.All, hitProp);
                 }
             }
         }

    [PunRPC]
    private void UpdateProp(Prop hitProp)
    {
        newMeshFilter.mesh         = hitProp.PropMeshFilter.sharedMesh;
        newMeshRenderer.material   = hitProp.PropMeshRenderer.material;
        newMeshCollider.sharedMesh = hitProp.PropMeshCollider.sharedMesh;
    }

    public void SayVoiceLine()
    {
        
    }

}


