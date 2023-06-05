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

    void Update()
    {
        if (PauseMenu.gameIsPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectStandardTurret();
            } else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectAnotherTurret();
            } else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectLaserBeamer();
            }
        } 

    }

    public void SelectStandardTurret()
    {
        Debug.Log("turret purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectAnotherTurret()
    {
        Debug.Log("missile turret purchased");
        buildManager.SelectTurretToBuild(anotherTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(LaserBeamerPrefab);
    }

}   