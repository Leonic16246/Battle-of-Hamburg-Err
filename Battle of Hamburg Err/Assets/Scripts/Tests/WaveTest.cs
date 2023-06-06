using NUnit.Framework;
using UnityEngine;

public class WaveTest
{
    private Wave wave;
    private GameObject enemy;

    [SetUp]
    public void SetUp()
    {
        enemy = new GameObject();
        wave = new Wave
        {
            enemy = enemy,
            count = 10,
            rate = 1f
        };
    }

    [Test]
    public void Wave_CanSetFieldsCorrectly()
    {
        Assert.AreEqual(enemy, wave.enemy);
        Assert.AreEqual(10, wave.count);
        Assert.AreEqual(1f, wave.rate);
    }
}