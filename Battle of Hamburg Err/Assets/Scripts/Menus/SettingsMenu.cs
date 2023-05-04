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

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

}
