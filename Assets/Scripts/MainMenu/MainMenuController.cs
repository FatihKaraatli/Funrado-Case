using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Settings Panel")]
    public GameObject settingsPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
