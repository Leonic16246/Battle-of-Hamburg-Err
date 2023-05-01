using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class themselector : MonoBehaviour
{
    public void SelectAmerica()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject prefabInstance = Instantiate(Resources.Load<GameObject>("AMap")) as GameObject;

    }

    public void SelectDefault()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject prefabInstance = Instantiate(Resources.Load<GameObject>("Environment")) as GameObject;

    }
}
