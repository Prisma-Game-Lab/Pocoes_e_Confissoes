using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("VolumeSettings")]
    [SerializeField] private TextMeshProUGUI volumeTextValue;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume;

    private void Awake()
    {
        LoadSettings();
    }
    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            SetVolume(PlayerPrefs.GetFloat("masterVolume"));
        }
        else
        {
            ResetValues("audio");
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume/100f;
        volumeSlider.value = volume;
        volumeTextValue.text = volume.ToString();
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void ResetValues(string s)
    {
        switch (s)
        {
            case "audio":
                SetVolume(defaultVolume);
                break;

            default:
                SetVolume(defaultVolume);
                break;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
