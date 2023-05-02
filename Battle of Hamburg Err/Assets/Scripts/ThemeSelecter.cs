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
    public GameObject mapGO;

    string sceneName = "GameScene";


    public void SelectAmerica()
    {
        //changes to the GameScene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Instantiate(Amap, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public void SelectDefault()
    {   
        

        //SceneManager.MoveGameObjectToScene(Environment, SceneManager.GetSceneByName(sceneName));
        SceneManager.LoadScene(1);

        mapGO = Instantiate(Amap, new Vector3(0, 0, 0), Quaternion.identity);
        DontDestroyOnLoad(mapGO);
        //SceneManager.MoveGameObjectToScene(mapGO, SceneManager.GetSceneByName(sceneName));    
        
    }
    IEnumerator LoadYourAsyncScene()
    {


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        

    }
}
