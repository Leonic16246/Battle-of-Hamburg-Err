using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{

    // for audio
    public AudioMixer audioMixer;
    public bool masterMute = false, musicMute = false, sfxMute = false;
    public float masterFloat = 0, musicFloat = 0, sfxFloat = 0;
    public TextMeshProUGUI masterText, musicText, sfxText;

    // for resolutions
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;

    [SerializeField]
    Difficulty difficulty;


    /** 
The Start() method is called when the script is first enabled or when the game object it is attached to is instantiated.
This method is responsible for initializing the resolution dropdown menu with available resolution options.
It retrieves the available screen resolutions using Screen.resolutions and populates the dropdown menu with the options.
It also sets the default value of the dropdown to the current screen resolution and refreshes the shown value.
*/

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        // convert array of resolution types to a list of strings
        List<string> options = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + "@" + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetMaster(float volume)
    {
        masterFloat = volume;
        if (!masterMute)
        {
            audioMixer.SetFloat("Master", volume);
        }
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
    }

    /**
 * Sets the music volume to the specified value in decibels.
 * 
 * @param volume The volume level for the music. Value ranges from 0 to 1.
 */

    public void SetMusic(float volume)
    {
        musicFloat = volume;
        if (!musicMute)
        {
            audioMixer.SetFloat("Music", volume);
        }
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
    }

    public void SetSFX(float volume)
    {
        sfxFloat = volume;
        if (!sfxMute)
        {
            audioMixer.SetFloat("SFX", volume);
        }
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
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    /**
 * Sets the screen resolution to the specified index in the resolutions array, using pixel measurements.
 * 
 * @param resIndex The index of the desired resolution in the resolutions array.
 */

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    // Change the health and speed multipliers when difficulty is changed.
    public void SetDifficulty(int difficultyValue)
    {
        difficulty.Set(difficultyValue);
    }
}
