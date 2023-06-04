using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false, inOtherMenu = false;
    public GameObject pauseMenuUI, settingsMenuUI, currentMenuUI;

    public static float gameSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentMenuUI == pauseMenuUI)
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        } else if (Input.GetKeyDown(KeyCode.Escape) && currentMenuUI != pauseMenuUI)
        {
            Back(currentMenuUI);
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
        DataPersistenceManager.instance.SaveGame();
    }

    public void LoadButton()
    {
        Debug.Log("load");
        DataPersistenceManager.instance.LoadGame();
    }


    public void SettingsButton()
    {
        Debug.Log("option");
        currentMenuUI = settingsMenuUI;
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }


    public void QuitButton()
    {
        Debug.Log("quit");
        Destroy(GameObject.FindGameObjectWithTag("MapManager")); // destroy mapmanger so the theme buttons can reference the mapmanger instance created in the new mainmenu scene
        SceneManager.LoadScene(0);
    }


    public void Back(GameObject menuUI) // where menuUI is current Menu to back out of
    {
        Debug.Log("back");
        pauseMenuUI.SetActive(true);
        menuUI.SetActive(false);
        currentMenuUI = pauseMenuUI;
    }

    public void SetSpeed(float value)
    {
        gameSpeed = value;
    }

}
