using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerStats : MonoBehaviour, IDataPersistence
{
    public int startingMoney = 1000;
    public static int Money;

    public static int playerXP, playerLevel, skillPoints = 0;

    private static int xpUntilNextLevel;
    public TextMeshProUGUI levelUpText;

    public Image healthBar;
    public static float health = 1;

    public GameObject gameOverScreen;

    public static PlayerStats instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one PlayerStats instance");
            return;
        }

        instance = this;
    }

    public void SaveData(ref GameData data)
    {
        data.Money = this.startingMoney;
        data.playerXP = playerXP;
        data.playerLevel = playerLevel;
        data.xpUntilNextLevel = xpUntilNextLevel;
    }

    public void LoadData(GameData data)
    {
        Money = this.startingMoney;
        Debug.Log(Money);
        playerXP = data.playerXP;
        Debug.Log(playerXP);
        playerLevel = data.playerLevel;
        Debug.Log(playerLevel);
        xpUntilNextLevel = data.xpUntilNextLevel;
        Debug.Log(xpUntilNextLevel);
        
        if (PlayerPrefs.HasKey("skill points"))
        {
            skillPoints = PlayerPrefs.GetInt("skill points");
        }
    }

    // Called when enemy reaches the end of their path, reducing the player's health.
    public void ReducePlayerHealth(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health;
        if (health <= 0) // Game over when health reaches 0.
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            gameOverScreen.GetComponentInChildren<TextMeshProUGUI>().text = "Game over";
        }
    }

    // Called on enemy defeat, increasing the player's XP.
    public void GainXP(int amount)
    {
        playerXP += amount;
        
        // Increment player level when playerXP reaches or exceeds a certain amount.
        // Add skill points based on player's level.
        Debug.Log("XP: "+playerXP);
        if (playerXP >= xpUntilNextLevel)
        {
            playerLevel++;
            playerXP = 0;
            if (playerLevel < 5)
            {
                skillPoints++;
            }
            else if (5 <= playerLevel && playerLevel < 10)
            {
                skillPoints += 2;
            }
            else
            {
                skillPoints += 3;
            }
            Debug.Log("Skill points: "+skillPoints);
            StartCoroutine(sendNotification(5));

            xpUntilNextLevel = Mathf.RoundToInt((float)1.2 * xpUntilNextLevel);
        }

        // Keep the XP values to use in the main menu scene.
        PlayerPrefs.SetInt("level", playerLevel);
        PlayerPrefs.SetInt("skill points", skillPoints);
        PlayerPrefs.SetFloat("xp", GetXPBarFill());
    }

    // Set the "level up" message to be visible for a number of seconds.
    IEnumerator sendNotification(int time)
    {
        levelUpText.text = "Level up!\n" +
            "Current level: "+playerLevel;
        levelUpText.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        levelUpText.gameObject.SetActive(false);
    }

    // Return the float value to be used for setting the XP bar fill.
    public static float GetXPBarFill()
    {
        return (float)playerXP / (float)xpUntilNextLevel;
    }
}
