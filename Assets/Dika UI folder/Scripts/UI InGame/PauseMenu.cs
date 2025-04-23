using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject pauseHintUI;
    public GameObject audioSettingsUI;

    public bool isPaused = false;

    public VolumeSettings volumeSettings;

    
    void Start()
    {
        pauseMenuUI.SetActive(false);
        audioSettingsUI.SetActive(false);
        pauseHintUI.SetActive(true);
    }


    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;

        pauseMenuUI.SetActive(true);
        audioSettingsUI.SetActive(false);
        pauseHintUI.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        pauseMenuUI.SetActive(false);
        audioSettingsUI.SetActive(false);
        pauseHintUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OpenAudioSettings()
    {
        pauseMenuUI.SetActive(false);
        audioSettingsUI.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        audioSettingsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void BalikKePilihanGame()
    {
        Time.timeScale = 1f;
        if (volumeSettings != null)
        {
            volumeSettings.MuteAll(); // mute kalau mixer tersedia
        }

        if (ManajerSuara.Instance != null)
        {
            Destroy(ManajerSuara.Instance.gameObject); // hancurkan kalau ingin reset
        }
        volumeSettings.MuteAll();

        UnityEngine.SceneManagement.SceneManager.LoadScene("UI (BukanInGame)");

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe agar tidak ter-trigger lagi
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Temukan objek yang mewakili thumbnail kedua pada scene yang baru dimuat
        GameObject thumbnailKedua = GameObject.Find("ThumbnailKedua");  // Gantilah dengan nama objek yang sesuai

        // Aktifkan objek thumbnail kedua jika ditemukan
        if (thumbnailKedua != null)
        {
            thumbnailKedua.SetActive(true);
        }
        else
        {
            Debug.Log("Thumbnail Kedua tidak ditemukan di scene.");
        }
    }

    // 🆕 Fungsi untuk tombol pause manual
    public void OnPauseButtonClicked()
    {
        if (!isPaused)
        {
            PauseGame();
        }
    }

}
