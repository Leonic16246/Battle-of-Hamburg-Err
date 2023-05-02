using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 1000;

    public static int playerXP;
    public static int playerLevel;

    public Image healthBar;
    public static float health = 1;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        playerXP = 0;
        playerLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!health.Equals(healthBar.fillAmount))
        {
            healthBar.fillAmount = health;
        }
    }

    public static void ReducePlayerHealth(float amount)
    {
        health -= amount;
    }

    public static void GainXP(int amount)
    {
        playerXP += amount;

        // TODO: Increment player level when playerXP reaches or exceeds a certain amount.
        Debug.Log("XP: "+playerXP);
    }
}
