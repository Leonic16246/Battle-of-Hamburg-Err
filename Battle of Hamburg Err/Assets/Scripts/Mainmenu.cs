using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    public GameObject mainMenuUI, themeMenuUI;

    public void New()
    {
        mainMenuUI.SetActive(false);
        themeMenuUI.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        themeMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
