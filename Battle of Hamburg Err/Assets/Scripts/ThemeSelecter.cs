//have to drag the prefab into the my prefab field as component but i cant find it....
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeSelecter : MonoBehaviour
{

    public static ThemeSelecter instance;


    /**
The Awake() method is called when the script is first loaded into the scene.
Its purpose is to ensure that only one instance of the ThemeSelecter exists and persists between scene loads.
If there is no existing instance, the current instance is assigned to the 'instance' variable.
If an instance already exists, the current instance is destroyed to maintain singularity.
Finally, the gameObject to which this script is attached is marked as 'Don't Destroy On Load',
ensuring that it persists when new scenes are loaded.
*/

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
        // Check if the current scene is not the desired scene for the map
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            // Start a coroutine to wait for the scene to finish loading before instantiating the selected map
            StartCoroutine("waitForSceneLoad", 1);
        }


    }

    public void SelectJapan()
    {   
        mapToLoad = Jmap;
        // Check if the current scene is not the desired scene for the map
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            // Start a coroutine to wait for the scene to finish loading before instantiating the selected map
            StartCoroutine("waitForSceneLoad", 1);
        }
 
        
    }

    public void SelectDesert()
    {
        mapToLoad = Dmap;
        // Check if the current scene is not the desired scene for the map
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            // Start a coroutine to wait for the scene to finish loading before instantiating the selected map
            StartCoroutine("waitForSceneLoad", 1);
        }


    }
    IEnumerator waitForSceneLoad(int sceneNumber)
    {

        // Handles the asynchronous loading of the scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            yield return null;
        }

        if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
            // Instantiates the selected map object in the scene
            Instantiate(mapToLoad, mapToLoad.transform.position, mapToLoad.transform.rotation);
        }

    }
}
