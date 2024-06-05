using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class PlayerLevelController : MonoBehaviour, IPlayerLevel
{
    public int playerLevelCount { get; set; } = 1;

    [Header("UI")]
    public TextMeshProUGUI levelLevelText;

    [Header("Effect")]
    public ParticleSystem levelIncreaseEffect;

    public static PlayerLevelController instance { get; private set; }

    private GameObject[] enemiesList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        enemiesList = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        levelLevelText.transform.LookAt(Camera.main.transform.position);
    }

    public void SetLevel(int increaseCount)
    {
        playerLevelCount += increaseCount;
        levelLevelText.text = "Lv. " + playerLevelCount;

        int nullCounter = 0;

        foreach (GameObject item in enemiesList)
        {
            if (item != null)
            {
                nullCounter++;
                item.GetComponent<EnemyLevelController>().LevelColorChange(playerLevelCount);
            }
        }

        levelIncreaseEffect.Play();
    }

}
