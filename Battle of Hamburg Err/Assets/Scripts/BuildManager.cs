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
    public GameObject LaserBeamerPrefab;    

    private TurretBlueprint turretToBuild;
    private Node selectedNode; 

    public NodeUI nodeUI;

    // Apply the permanent upgrades to the turret prefabs based on the levels stored.
    private void Start()
    {
        if (!PlayerPrefs.HasKey("burger turret"))
        {
            PlayerPrefs.SetInt("burger turret", 0);
        }

        if (!PlayerPrefs.HasKey("sushi launcher"))
        {
            PlayerPrefs.SetInt("sushi launcher", 0);
        }

        if (!PlayerPrefs.HasKey("donut laser"))
        {
            PlayerPrefs.SetInt("donut laser", 0);
        }

        UpgradeBurgerTurret(PlayerPrefs.GetInt("burger turret"));
        UpgradeSushiLauncher(PlayerPrefs.GetInt("sushi launcher"));
        UpgradeDonutLaser(PlayerPrefs.GetInt("donut laser"));
    }

    public bool CanBuild()
    {
        return turretToBuild != null;
    }

    public bool HasMoney()
    {
        return PlayerStats.Money >= turretToBuild.cost;
    }


    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide(); 
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode(); 
    }

    public TurretBlueprint GetTurretToBuild() // calls a turret from the shop
    {
        return turretToBuild; 
    }

    // Apply upgrades to the burger turret prefab.
    void UpgradeBurgerTurret(int level)
    {
        Turret burgerTurret = standardTurretPrefab.GetComponent<Turret>();
        if (level >= 1)
        {
            burgerTurret.pelletprefab.GetComponent<Pellet>().damage = 75;
            if (level >= 2)
            {
                burgerTurret.range = 45;
                if (level == 3)
                {
                    burgerTurret.fireRate = 2;
                }
            }
        }
        else
        {
            // Default values
            burgerTurret.pelletprefab.GetComponent<Pellet>().damage = 50;
            burgerTurret.range = 25;
            burgerTurret.fireRate = 1;
        }
    }

    // Apply upgrades to the sushi launcher missile prefab.
    void UpgradeSushiLauncher(int level)
    {
        Pellet sushiLauncherMissile = anotherTurretPrefab.GetComponent<Turret>().pelletprefab.GetComponent<Pellet>();
        if (level >= 1)
        {
            sushiLauncherMissile.damage = 150;
            if (level >= 2)
            {
                sushiLauncherMissile.explosionRadius = 20;
                if (level == 3)
                {
                    sushiLauncherMissile.speed = 50;
                }
            }
        }
        else
        {
            // Default values
            sushiLauncherMissile.damage = 100;
            sushiLauncherMissile.explosionRadius = 10;
            sushiLauncherMissile.speed = 30;
        }
    }

    // Apply upgrades to the donut laser prefab.
    void UpgradeDonutLaser(int level)
    {
        Turret donutLaser = LaserBeamerPrefab.GetComponent<Turret>();
        if (level >= 1)
        {
            donutLaser.slowAmount = 0.25f;
            if (level >= 2)
            {
                donutLaser.damageOverTime = 55;
                if (level == 3)
                {
                    donutLaser.range = 50;
                }
            }
        }
        else 
        {
            // Default values
            donutLaser.slowAmount = 0.5f;
            donutLaser.damageOverTime = 30;
            donutLaser.range = 30;
        }
    }
}
