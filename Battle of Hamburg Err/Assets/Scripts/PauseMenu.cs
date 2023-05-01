using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public static float gameSpeed = 1;

    public static PauseMenu instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one pause menu");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        Time.timeScale = gameSpeed;
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

    public void OptionButton()
    {
        Debug.Log("option");

        // Open the options menu
        pauseMenuUI.SetActive(false);
        OptionsMenu.instance.Open();
    }


    public void QuitButton()
    {
        Debug.Log("quit");
    }

}
