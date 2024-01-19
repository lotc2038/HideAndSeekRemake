using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IProp, IDamageable
{
    private Health health = new Health();

    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
}
