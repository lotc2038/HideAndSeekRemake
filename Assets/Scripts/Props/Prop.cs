using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Prop : MonoBehaviourPunCallbacks, IDamageable
{
    private Health health = new Health();
    public MeshRenderer PropMeshRenderer { get; private set; }
    public MeshCollider PropMeshCollider { get; private set; }
    public MeshFilter   PropMeshFilter   { get; private set; }
    
    //TODO: Может сделать тип объекта (легкий, средний, тяжелый) и на основе этого ставить скорость?
    
    public  PhotonView pv;
    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
    
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        PropMeshRenderer = GetComponent<MeshRenderer>();
        PropMeshCollider = GetComponent<MeshCollider>();
        PropMeshFilter   = GetComponent<MeshFilter>();
    }
    
    
}
