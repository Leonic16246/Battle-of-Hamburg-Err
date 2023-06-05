//have to drag the prefab into the my prefab field as component but i cant find it....
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeSelecter : MonoBehaviour
{

    public static ThemeSelecter instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public GameObject Amap;
    public GameObject Jmap;
    public GameObject Dmap;
    GameObject mapToLoad;

    string sceneName = "GameScene";


    public void SelectAmerica()
    {
        mapToLoad = Amap;
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            StartCoroutine("waitForSceneLoad", 1);
        }


    }

    public void SelectJapan()
    {   
        mapToLoad = Jmap;
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            StartCoroutine("waitForSceneLoad", 1);
        }
 
        
    }

    public void SelectDesert()
    {
        mapToLoad = Dmap;
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            StartCoroutine("waitForSceneLoad", 1);
        }


    }
    IEnumerator waitForSceneLoad(int sceneNumber)
    {


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            yield return null;
        }

        if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
            Instantiate(mapToLoad, mapToLoad.transform.position, mapToLoad.transform.rotation);
        }

    }
}
