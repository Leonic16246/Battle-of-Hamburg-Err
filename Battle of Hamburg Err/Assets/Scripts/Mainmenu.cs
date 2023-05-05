using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Mainmenu : MonoBehaviour
{
    public GameObject mainMenuUI, themeMenuUI;
    public TextMeshProUGUI userLevelText;
    public Image xpBar;

    public static Mainmenu instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one main menu instance.");
            return;
        }

        instance = this;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("level") && !PlayerPrefs.HasKey("xp"))
        {
            SetUserXP(1, 0);
        }
        else
        {
            SetUserXP(PlayerPrefs.GetInt("level"), PlayerPrefs.GetFloat("xp"));
        }
    }

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

    public void SetUserXP(int playerLevel, float xpBarFill)
    {
        userLevelText.text = "User Level: "+playerLevel;
        xpBar.fillAmount = xpBarFill;
    }
}
