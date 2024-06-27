using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;

    public HealthBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount) 
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth, maxHealth);

        if(currentHealth <= 0) 
        {
            Debug.Log("Player Died");
            ScoreManager.instance.EndGame();
        }
    }
}
