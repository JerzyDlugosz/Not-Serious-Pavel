using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private AudioManager audioManager;
    public Dropdown res;
    public Slider slider;
    public Dropdown quality;
    public Toggle fullscreen;
    List<Resolution> resolutions = new List<Resolution>();

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        int a = 0;
        foreach (var item in Screen.resolutions)
        {
            if(item.width > 1024)
            {
                resolutions.Add(item);
                a++;
            }
        }
        res.ClearOptions();
        List<string> ResOptions = new List<string>();
        int currRes = 0;
        int i = 0;
        foreach(var item in resolutions)
        {
            ResOptions.Add(item.width + "x" + item.height);

            if (item.width == Screen.width && item.height == Screen.height)
            {
                currRes = i;
            }
            i++;
        }
        res.AddOptions(ResOptions);
        res.value = currRes;
        res.RefreshShownValue();
        slider.value = audioManager.sounds[14].source.volume;
         fullscreen.isOn = Screen.fullScreen;
        quality.value = QualitySettings.GetQualityLevel();
    }

    public void SetVolume(float volume)
    {
        audioManager.SetVolume(volume);
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int res)
    {
        Resolution resolution = resolutions[res];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
