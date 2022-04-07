using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider FXSlider;
    [SerializeField] private float multiplier;
    [SerializeField] private TextMeshProUGUI MusicTextValue;
    [SerializeField] private TextMeshProUGUI FXTextValue;
    [SerializeField] private float defaultVolume;

    private void Start()
    {
        LoadSettings();
    }
    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("SoundFXVolume") && PlayerPrefs.HasKey("MusicVolume"))
        {
            SetFxVolume(PlayerPrefs.GetFloat("SoundFXVolume"));
            SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        }
        else
        {
            ResetValues("audio");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void ResetValues(string type)
    {
        switch (type)
        {
            case "audio":
                SetFxVolume(defaultVolume);
                SetMusicVolume(defaultVolume);
                break;
            default:
                SetFxVolume(defaultVolume);
                SetMusicVolume(defaultVolume);
                break;
        }
    }


    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void SetFxVolume(float volume)
    {
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log10((volume != 0)? volume/100f : -80f) * multiplier);
        PlayerPrefs.SetFloat("SoundFXVolume", volume);
        FXSlider.value = volume;
        FXTextValue.text = volume.ToString();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10((volume != 0)? volume/100f : -80f) * multiplier);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        MusicSlider.value = volume;
        MusicTextValue.text = volume.ToString();
    }
}
