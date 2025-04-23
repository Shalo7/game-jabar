using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        Debug.Log("VolumeSettings Start Called");

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            Debug.Log("Found saved volume settings");
            LoadVolume();
        }
        else
        {
            Debug.Log("No saved volume, using current slider value");
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    void Awake()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            PlayerPrefs.SetFloat("SFXVolume", 0.5f);
        }
    }


    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("musik", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        float musicVol = PlayerPrefs.GetFloat("musicVolume", 0.5f); // fallback kalau belum diset
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        Debug.Log("Music Volume Loaded: " + musicVol);
        Debug.Log("SFX Volume Loaded: " + sfxVol);

        musicSlider.value = musicVol;
        SFXSlider.value = sfxVol;

        SetMusicVolume();
        SetSFXVolume();
    }

    public void MuteAll()
    {
        myMixer.SetFloat("musik", -80f);
        myMixer.SetFloat("SFX", -80f);
    }



}
