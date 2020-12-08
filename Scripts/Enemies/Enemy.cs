using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startHealth = 100f;
    private float health;
    private float currentSpeed;
    private bool isDead = false;
    public int value = 5;
    public int scoreValue;

    public Image healthBar;

    private void Start() 
    {
        health = startHealth;
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
  
    }

    private void Die()
    {
        isDead = true;
        PlayerStats.Money += value;
        PlayerStats.Score += scoreValue;
        WaveSpawner.EnemiesAlive --;

        Destroy(gameObject);
    }
}
