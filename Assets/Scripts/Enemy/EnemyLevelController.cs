using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyLevelController : MonoBehaviour , IEnemyLevel
{
    [field: SerializeField] public int enemyLevelCount { get; set; } = 1;

    [Header("UI")]
    public TextMeshProUGUI levelLevelText;

    private void Start()
    {
        levelLevelText.text = "Lv. " + enemyLevelCount;
    }

    private void Update()
    {
        levelLevelText.transform.LookAt(Camera.main.transform.position);
    }

    public void LevelColorChange(int playerLevel)
    {
        if(playerLevel > enemyLevelCount)
        {
            levelLevelText.color = Color.green;
        }
    }
}
