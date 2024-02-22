using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IDamageable
{
    private Health health = new Health();
    public MeshRenderer PropMeshRenderer { get; private set; }
    public MeshCollider PropMeshCollider { get; private set; }
    public MeshFilter   PropMeshFilter   { get; private set; }
    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
    
    private void Awake()
    {
        PropMeshRenderer = GetComponent<MeshRenderer>();
        PropMeshCollider = GetComponent<MeshCollider>();
        PropMeshFilter   = GetComponent<MeshFilter>();
    }
    
}
