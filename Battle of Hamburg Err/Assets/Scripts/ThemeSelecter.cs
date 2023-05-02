//have to drag the prefab into the my prefab field as component but i cant find it....
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeSelecter : MonoBehaviour
{
    public GameObject Amap;
    public GameObject Environment;

    public void SelectAmerica()
    {
        //changes to the GameScene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Instantiate(Amap, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public void SelectDefault()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject mapGO = Instantiate(Environment, transform.position, transform.rotation);
        


    }
}
