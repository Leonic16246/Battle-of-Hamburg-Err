using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 1000;

    public Image healthBar;
    public static float health = 1;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
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
}
