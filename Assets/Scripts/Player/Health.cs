using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Health : IDamageable
{
    private int currentHealth;
    private const int maxHealth = 100;
    public event Action onDeath;

    public Health()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Current Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            onDeath?.Invoke();
        }
    }
}
