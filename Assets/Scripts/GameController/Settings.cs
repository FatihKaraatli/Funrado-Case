using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Sound Buttons")]
    public GameObject soundOnButton;
    public GameObject soundOffButton;

    [Header("Settings Panel")]
    public GameObject settingsPanel;

    public void Start()
    {
        if (PlayerPrefs.GetString("Sound").Equals("On") || PlayerPrefs.GetString("Sound") == "")
        {
            soundOnButton.SetActive(true);
            soundOffButton.SetActive(false);
            audioSource.mute = false;
        }
        else
        {
            soundOnButton.SetActive(false);
            soundOffButton.SetActive(true);
            audioSource.mute = true;
        }
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        settingsPanel.SetActive(false);
    }

    public void SoundOnButton()
    {
        PlayerPrefs.SetString("Sound", "Off");
        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
        audioSource.mute = true;
    }

    public void SoundOffButton()
    {
        PlayerPrefs.SetString("Sound", "On");
        soundOnButton.SetActive(true);
        soundOffButton.SetActive(false);
        audioSource.mute = false;
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
