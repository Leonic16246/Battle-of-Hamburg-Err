using NUnit.Framework;
using UnityEngine;

public class DifficultyTest
{
    Difficulty difficulty;

    [SetUp]
    public void SetUp()
    {
        difficulty = new Difficulty();
    }
    
    [Test] // Passes if health is changed correctly on easy mode.
    public void EasyHealth()
    {
        difficulty.Set(0);
        float health = Enemy.startHealth;
        Assert.AreEqual(50f, health);
    }

    [Test] // Passes if damage is set to default value on normal mode.
    public void NormalDamage()
    {
        difficulty.Set(1);
        float damage = Enemy.startDamage;
        Assert.AreEqual(0.05f, damage);
    }

    [Test] // Passes if speed is changed correctly on hard mode.
    public void HardSpeed()
    {
        difficulty.Set(2);
        float speed = Enemy.startSpeed;
        Assert.AreEqual(15f, speed);
    }
}
