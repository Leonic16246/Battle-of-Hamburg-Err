using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one build manager");
            return;
        }

        instance = this;
    }
    
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild()
    {
        return turretToBuild != null;
    }

    public bool HasMoney()
    {
        return PlayerStats.Money >= turretToBuild.cost;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("turret built, money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
