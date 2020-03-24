using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mix;

    public Dropdown resDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currRes = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currRes = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currRes;
        resDropdown.RefreshShownValue();
    }

    public void fullscreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetSFXVolume(float vol)
    {
        mix.SetFloat("sfxVolume", vol);
    }

    public void SetMusicVolume(float vol)
    {
        mix.SetFloat("musicVolume", vol);
    }

    public void SetRes(int resIndex)
    {
        Resolution r = resolutions[resIndex];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }
}
