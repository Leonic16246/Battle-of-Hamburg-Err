using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static float startSpeed = 10f;
    public static float startDamage = 0.05f;

    //[HideInInspector]
    public float speed;
    public float damage;

    public static float startHealth = 100;
    public float health;
    public int worth = 50;    

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar; 

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        damage = startDamage;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth; 

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth; 

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--; 

        Destroy(gameObject);
        PlayerStats.instance.GainXP(10); // Gain 10 XP on enemy defeat.
    }
}
