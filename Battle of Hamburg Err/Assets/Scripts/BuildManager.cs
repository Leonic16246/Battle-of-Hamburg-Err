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

    // Apply the permanent upgrades to the turret prefabs.
    private void Start()
    {
        if (PlayerPrefs.HasKey("test1") && PlayerPrefs.GetInt("test1") == 1)
        {
            Debug.Log("Test: "+ PlayerPrefs.GetInt("test1"));
            standardTurretPrefab.GetComponent<Turret>().fireRate = 5;
        }
    }

    public bool CanBuild()
    {
        return turretToBuild != null;
    }

    public bool HasMoney()
    {
        return PlayerStats.Money >= turretToBuild.cost;
    }


    public void SelectNode (Node node)
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

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild; 
    }

}
