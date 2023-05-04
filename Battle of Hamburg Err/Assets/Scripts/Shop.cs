using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;
    public TurretBlueprint LaserBeamerPrefab;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("turret purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectAnotherTurret()
    {
        Debug.Log("another turret purchased");
        buildManager.SelectTurretToBuild(anotherTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(LaserBeamerPrefab);
    }

}   