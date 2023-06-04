using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Upgrade()
    {
        
    }

    // Make the next upgrade in the tree available.
    public void EnableNext(GameObject next)
    {
        if (next != null)
        {
            next.GetComponent<Button>().interactable = true;
        }
    }
}
