using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ManajerSuara : MonoBehaviour
{
    [Header("..........Audio Sources..........")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("..........Audio Clip..........")]
    // tambahin beberapa sound lain ke sini //

    public AudioClip inGameMusic;
    public AudioClip jumpSound;
    public AudioClip pauseSound;
    public AudioClip winSound;

    public AudioMixer mixer;

    public static ManajerSuara Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // ini penting biar gak dobel
            return;
        }

        // Set volume langsung di awal
        float musicVol = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        musicSource.outputAudioMixerGroup.audioMixer.SetFloat("musik", Mathf.Log10(musicVol) * 20);
        sfxSource.outputAudioMixerGroup.audioMixer.SetFloat("SFX", Mathf.Log10(sfxVol) * 20);



    }


    private void Start()
    {
        musicSource.clip = inGameMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
