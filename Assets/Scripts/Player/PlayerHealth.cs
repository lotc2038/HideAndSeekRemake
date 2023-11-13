using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : IDamageable
{
    private int currentHealth;
    private const int maxHealth = 100;

    public PlayerHealth()
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
        }
    }
}
