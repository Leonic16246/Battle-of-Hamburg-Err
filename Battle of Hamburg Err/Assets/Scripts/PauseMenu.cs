using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false, inOtherMenu = false;

    public GameObject pauseMenuUI, settingsMenuUI;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inOtherMenu)
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    // temporary functions, will exist in another class with acutal use once user story for it is started
    public void SaveButton()
    {
        Debug.Log("save");
    }

    public void LoadButton()
    {
        Debug.Log("load");
    }


    public void SettingsButton()
    {
        Debug.Log("option");
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);


    }


    public void QuitButton()
    {
        Debug.Log("quit");
    }


    public void BackButton()
    {
        Debug.Log("back");
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }

}
