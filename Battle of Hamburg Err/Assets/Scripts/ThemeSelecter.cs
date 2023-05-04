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
    public GameObject defaultMap;
    GameObject mapToLoad;

    string sceneName = "GameScene";


    public void SelectAmerica()
    {
        //changes to the GameScene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Instantiate(Amap, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public void SelectDefault()
    {   
        mapToLoad = Amap;
        SceneManager.LoadScene(1);
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
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            Instantiate(mapToLoad, mapToLoad.transform.position, mapToLoad.transform.rotation);
            
        }

    }
}
