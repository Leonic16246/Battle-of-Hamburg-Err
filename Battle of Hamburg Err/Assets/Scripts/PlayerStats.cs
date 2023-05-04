using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 1000;

    public static int playerXP;
    public static int playerLevel;
    private static int xpUntilNextLevel;

    public Image healthBar;
    public static float health = 1;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        playerXP = 0;
        playerLevel = 1;
        xpUntilNextLevel = 750;
    }

    // Update is called once per frame
    void Update()
    {
        if (!health.Equals(healthBar.fillAmount))
        {
            healthBar.fillAmount = health;
        }
    }

    // Called when enemy reaches the end of their path, reducing the player's health.
    public static void ReducePlayerHealth(float amount)
    {
        health -= amount;
    }

    // Called on enemy defeat, increasing the player's XP.
    public static void GainXP(int amount)
    {
        playerXP += amount;

        // Increment player level when playerXP reaches or exceeds a certain amount.
        Debug.Log("XP: "+playerXP);
        if (playerXP >= xpUntilNextLevel)
        {
            playerLevel++;
            Debug.Log("Level Up!");
            Debug.Log("Current Level: "+playerLevel);

            xpUntilNextLevel = Mathf.RoundToInt((float)1.2 * xpUntilNextLevel);
            Debug.Log("XP until next level: " + xpUntilNextLevel);
        }
    }
}
