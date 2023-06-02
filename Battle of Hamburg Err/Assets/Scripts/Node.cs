using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColour, cantBuyColour;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false; 

    private Renderer rendr;
    private Color startColor;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        rendr = GetComponent<Renderer>();
        startColor = rendr.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild())
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = Instantiate(blueprint.prefab, GetPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint; 

        Debug.Log("Turret Built, Money left: " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to Upgrade!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //get rid of old turret
        Destroy(turret);

        //building new turret
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true; 

        Debug.Log("Turret Upgraded, Money left: " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);
        isUpgraded = false; 
        turretBlueprint = null; 
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild())
        {
            return;
        }

        if (buildManager.HasMoney())
        {
            GetComponent<Renderer>().material.color = hoverColour;
        } else
        {
            GetComponent<Renderer>().material.color = cantBuyColour;
        }
    }

    void OnMouseExit()
    {
        rendr.material.color = startColor;
    }

}
