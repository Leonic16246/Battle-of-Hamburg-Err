using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColour, cantBuyColour;

    [Header("optional")]
    public GameObject turret;

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
        
        if (!buildManager.CanBuild())
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("cant build here");
            return;
        }
        
        buildManager.BuildTurretOn(this);

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
