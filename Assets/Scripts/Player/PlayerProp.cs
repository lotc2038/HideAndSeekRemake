using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerProp : PlayerBase, IDamageable
{

    // TODO: Баг при превращении в предмет у другого игрока вызывает исключение collisionmeshdata couldn't be created, скорее всего нельзя передавать меш и прочее, но можно подкрутить модельку
    // PS Очень странный фикс в виде активации значения Convex у модели (где связь...)
    
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
        }


    }
    


    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }


    public void ChangeToProp()
         {
             var direction = transform.forward;
             var ray = new Ray(transform.position, direction);
     
             if (Physics.Raycast(ray, out var hitInfo, range))
             {
                 var hitProp = hitInfo.collider.GetComponent<Prop>();
                 if (hitProp != null)
                 {
                     RPC_PropChangeModel(hitProp);
                     photonView.RPC("RPC_PropChangeModel", RpcTarget.All, hitProp.pv.ViewID);
                 }
             }
         }
    
    [PunRPC]
    void RPC_PropChangeModel(int targetPropID)
    {
        if (photonView.IsMine)
            return;

        PhotonView targetPV = PhotonView.Find(targetPropID);

        if (targetPV.gameObject == null)
            return;

        newMeshFilter.mesh  = targetPV.gameObject.GetComponent<MeshFilter>().mesh;
        newMeshRenderer.material   = targetPV.gameObject.GetComponent<MeshRenderer>().material;
        newMeshCollider.sharedMesh = targetPV.gameObject.GetComponent<MeshCollider>().sharedMesh;
    }
    
    
    void RPC_PropChangeModel(Prop hitProp)
    {
        newMeshFilter.mesh         = hitProp.PropMeshFilter.sharedMesh;
        newMeshRenderer.material   = hitProp.PropMeshRenderer.material;
        newMeshCollider.sharedMesh = hitProp.PropMeshCollider.sharedMesh;
        
    }
    

    public void SayVoiceLine()
    {
        
    }

}


