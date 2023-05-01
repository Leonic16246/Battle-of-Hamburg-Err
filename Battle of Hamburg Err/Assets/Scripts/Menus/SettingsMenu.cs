using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public bool masterMute = false, musicMute = false, sfxMute = false;
    public float masterFloat = 0, musicFloat = 0, sfxFloat = 0;
    public TextMeshProUGUI masterText, musicText, sfxText;

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
}
