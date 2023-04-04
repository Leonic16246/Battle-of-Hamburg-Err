using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("turret purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }


}
