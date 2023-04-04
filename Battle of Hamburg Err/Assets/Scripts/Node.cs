using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColour;

    private GameObject turret;

    private Renderer rendr;
    private Color startColor;



    // Start is called before the first frame update
    void Start()
    {
        rendr = GetComponent<Renderer>();
        startColor = rendr.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("cant build here");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = hoverColour;

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
