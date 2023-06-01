using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TurretBlueprintTest
{
    private TurretBlueprint turretBlueprint;

    [SetUp]
    public void SetUp()
    {
        turretBlueprint = new TurretBlueprint
        {
            prefab = new GameObject(),
            cost = 150,
            upgradedPrefab = new GameObject(),
            upgradeCost = 200
        };
    }

 

    [Test]
    public void GetSellAmount_ReturnsHalfCost()
    {
        int sellAmount = turretBlueprint.GetSellAmount();
        Assert.AreEqual(75, sellAmount);
    }
}
    