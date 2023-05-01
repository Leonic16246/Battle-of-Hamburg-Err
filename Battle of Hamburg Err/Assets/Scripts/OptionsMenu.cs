using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenuUI;

    public TextMeshProUGUI speedText;
    public Slider speedSlider;

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

    // Updates the speed value displayed next to the slider.
    public void UpdateSpeedText()
    {
        speedText.text = Math.Round(speedSlider.value, 2).ToString()+"x";
    }

    // Go back to the main menu on button click
    public void Close()
    {
        optionsMenuUI.SetActive(false);
        PauseMenu.gameSpeed = (float)Math.Round(speedSlider.value, 2); // Updates the game speed value in the PauseMenu instance.
        PauseMenu.instance.Pause();
    }
}
