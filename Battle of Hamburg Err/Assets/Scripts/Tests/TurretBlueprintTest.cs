using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TurretBlueprintTest
{
    [Test]
    public void TurretUpgrade_PrefabAndCostSet()
    {
        // Arrange
        var turretBlueprint = new TurretBlueprint
        {
            prefab = new GameObject(),
            cost = 100,
            upgradedPrefab = new GameObject(),
            upgradeCost = 200
        };

        // Act
        var upgradedPrefab = turretBlueprint.upgradedPrefab;
        var upgradeCost = turretBlueprint.upgradeCost;

        // Assert
        Assert.IsNotNull(upgradedPrefab);
        Assert.Greater(upgradeCost, turretBlueprint.cost);
    }
}
