using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenuUI;

    public static OptionsMenu instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one options menu");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Opens the options menu
    public void Open()
    {
        optionsMenuUI.SetActive(true);
    }

    // Updates the game speed value in the PauseMenu instance on speed button click
    public void UpdateSpeed(float amount)
    {
        PauseMenu.gameSpeed = amount; 

    }

    // Go back to the main menu on button click
    public void Close()
    {
        optionsMenuUI.SetActive(false);
        PauseMenu.instance.Pause();
    }
}
