using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    // Enemy stat multipliers
    [SerializeField]
    float healthMultiplier, speedMultiplier, dmgMultiplier;

    void Start()
    {
        Default();
    }

    // Modify enemy stat multipliers based on difficulty selected.
    public void Set(int difficultyValue)
    {
        if (difficultyValue == 0)
        {
            // Easy: Health/damage 50%, speed 75%
            healthMultiplier = 0.5f;
            speedMultiplier = 0.75f;
            dmgMultiplier = 0.5f;
        }
        else if (difficultyValue == 1)
        {
            // Normal
            Default();
        }
        else if (difficultyValue == 2)
        {
            // Hard: Health/speed 150%, damage 200%
            healthMultiplier = 1.5f;
            speedMultiplier = 1.5f;
            dmgMultiplier = 2f;
        }

        UpdateEnemyStats();
    }

    void Default()
    {
        healthMultiplier = 1f;
        speedMultiplier = 1f;
        dmgMultiplier = 1f;
    }

    void UpdateEnemyStats()
    {
        // Update start values for enemy health, speed and damage.
        Enemy.startHealth = 100f * healthMultiplier;
        Enemy.startSpeed = 10f * speedMultiplier;
        Enemy.startDamage = 0.05f * dmgMultiplier;

        // Get all active enemy objects in the current scene, update their health, speed and damage.
        GameObject[] scene = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject obj in scene)
        {
            Enemy enemy;
            if ((enemy = obj.GetComponent<Enemy>()) != null)
            {
                enemy.health = Enemy.startHealth;
                enemy.speed = Enemy.startSpeed;
                enemy.damage = Enemy.startDamage;
            }
        }
    }
}
