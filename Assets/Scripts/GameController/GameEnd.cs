using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public static GameEnd instance { get; private set; }

    [Header("UI")]
    public GameObject gameWinPanel;
    public GameObject gameLostPanel;

    private void Awake()
    {
        instance = this;
    }

    public void PlayerWin()
    {
        gameWinPanel.SetActive(true);
    }

    public void PlayerLost() 
    {
        gameLostPanel.SetActive(true);
    }    
}
