using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 1000;
    public static float health;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        health = healthBar.fillAmount;
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
        if (health > 0)
        {
            health -= amount;
        }
    }
}
