using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerProp : PlayerBase, IDamageable
{

    public float range = 100f;
    public MeshRenderer newMeshRenderer;
    public MeshFilter newMeshFilter;
    public MeshCollider newMeshCollider;
    //public Rigidbody newRigidBody;
    private void Start()
    {
       // gameObject.GetComponent<MeshRenderer>();
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
        if (Physics.Raycast(ray, out RaycastHit hitInfo, range))
        {
            var hitCollider = hitInfo.collider;
            MeshRenderer meshRenderer = hitInfo.collider.GetComponent<MeshRenderer>();
            MeshCollider meshCollider = hitInfo.collider.GetComponent<MeshCollider>();
            MeshFilter meshFilter = hitInfo.collider.GetComponent<MeshFilter>();
          //  Rigidbody rigidbody = hitInfo.collider.GetComponent<Rigidbody>();
            if (meshFilter != null)
            {
                newMeshFilter.mesh = meshFilter.sharedMesh;
                newMeshRenderer.material = meshRenderer.material;
                newMeshCollider.sharedMesh = meshCollider.sharedMesh;
               // newRigidBody = rigidbody;

            }
        }
    }


    public void SayVoiceLine()
    {
        
    }

}


