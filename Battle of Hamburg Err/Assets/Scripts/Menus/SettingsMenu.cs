using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{

    // for audio
    public AudioMixer audioMixer;
    public bool masterMute, musicMute, sfxMute;
    public static float masterFloat, musicFloat, sfxFloat;
    public TextMeshProUGUI masterText, musicText, sfxText;

    // for resolutions
    static Resolution[] resolutions;
    static bool searchedResolutions = false;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Slider masterSlider, musicSlider, sfxSlider;
    static int currentResIndex = 0;
    public Toggle fullToggle;
    static bool isFull = true;

    // convert array of resolution types to a list of strings
    static List<string> options = new List<string>();

    [SerializeField]
    Difficulty difficulty;

    void Start()
    {

        resolutionDropdown.ClearOptions();

            if (!searchedResolutions)
            {
                resolutions = Screen.resolutions;

            

            
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height + "@" + resolutions[i].refreshRate + "hz";
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResIndex = i;
                }
            }
            searchedResolutions = true;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();

        fullToggle.isOn = isFull;

        NewScene();

    }

    public void NewScene()
    {
        masterFloat = AudioManager.masterFloat;
        musicFloat =  AudioManager.musicFloat;
        sfxFloat =  AudioManager.sfxFloat;

        masterMute =  AudioManager.masterMute;
        musicMute =  AudioManager.musicMute;
        sfxMute =  AudioManager.sfxMute;

        masterSlider.value = masterFloat;
        musicSlider.value = musicFloat;
        sfxSlider.value = sfxFloat;

        if (masterMute)
        {
            masterText.color = Color.red;
        }
        if (musicMute)
        {
            musicText.color = Color.red;
        }
        if (sfxMute)
        {
            sfxText.color = Color.red;
        }
    }

    public void SetMaster(float volume)
    {
        masterFloat = volume;
        if (!masterMute)
        {
            audioMixer.SetFloat("Master", volume);
        }
        AudioManager.masterFloat = masterFloat;
    }
    public void MuteMaster()
    {
        if (!masterMute)
        {
            audioMixer.SetFloat("Master", -80);
            masterMute = true;
            masterText.color = Color.red;
        } else
        {
            masterMute = false;
            audioMixer.SetFloat("Master", masterFloat);
            masterText.color = Color.black;
        }
        AudioManager.masterMute = masterMute;
    }

    public void SetMusic(float volume)
    {
        musicFloat = volume;
        if (!musicMute)
        {
            audioMixer.SetFloat("Music", volume);
        }
        AudioManager.musicFloat = musicFloat;
    }
    public void MuteMusic()
    {
        if (!musicMute)
        {
            audioMixer.SetFloat("Music", -80);
            musicMute = true;
            musicText.color = Color.red;
        } else
        {
            musicMute = false;
            audioMixer.SetFloat("Music", musicFloat);
            musicText.color = Color.black;
        }
        AudioManager.musicMute = musicMute;
    }

    public void SetSFX(float volume)
    {
        sfxFloat = volume;
        if (!sfxMute)
        {
            audioMixer.SetFloat("SFX", volume);
        }
        AudioManager.sfxFloat = sfxFloat;
    }
    public void MuteSFX()
    {
        if (!sfxMute)
        {
            audioMixer.SetFloat("SFX", -80);
            sfxMute = true;
            sfxText.color = Color.red;
        } else
        {
            sfxMute = false;
            audioMixer.SetFloat("SFX", sfxFloat);
            sfxText.color = Color.black;
        }
        AudioManager.sfxMute = sfxMute;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        isFull = isFullScreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        currentResIndex = resIndex;
    }

    // Change the health and speed multipliers when difficulty is changed.
    public void SetDifficulty(int difficultyValue)
    {
        difficulty.Set(difficultyValue);
    }
}
