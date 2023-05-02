

//have to drag the prefab into the my prefab field as component but i cant find it....
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class themselector : MonoBehaviour
{
    public GameObject Amap;
    public GameObject Environment;

    public void SelectAmerica()
    {
        //changes to the GameScene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Instantiate(Amap, new Vector3(0, 0, 0), Quaternion.identity;

    }

    public void SelectDefault()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Instantiate(Environment, new Vector3(0, 0, 0), Quaternion.identity;

    }
}