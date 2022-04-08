using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("VolumeSettings")]
    [SerializeField] private TextMeshProUGUI MusicTextValue;
    [SerializeField] private TextMeshProUGUI FXTextValue;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider FXSlider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float defaultVolume;
    [SerializeField] private float multiplier;
    public GameObject FadeIn;
    public GameObject FadeOut;
    public GameObject creditsContainer;
    public GameObject mainContainer;

    private void Start()
    {
        if (GameStateManager.instance.completed)
        {
            
            Instantiate(FadeIn);
            creditsContainer.SetActive(true);
            mainContainer.SetActive(false);
            GameStateManager.instance.completed = false;
            GameStateManager.instance.order = new List<int>();
            GameStateManager.instance.currentClient = -1;
        }
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

    public void SetFxVolume(float volume)
    {
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log10((volume != 0)? volume/100f : -80f) * multiplier + 10);
        PlayerPrefs.SetFloat("SoundFXVolume", volume);
        FXSlider.value = volume;
        FXTextValue.text = volume.ToString();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10((volume != 0)? volume/100f : -80f) * multiplier + 10);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        MusicSlider.value = volume;
        MusicTextValue.text = volume.ToString();
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

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
