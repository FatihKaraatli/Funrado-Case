using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour
{
    public static HitDetect instance { get; private set; }

    [Header("Player Level Increase Count")]
    [SerializeField] private int playerLevelIncreaseCount = 1;

    private void Awake()
    {
        instance = this;
    }

    public void DeathDecider(GameObject player, GameObject enemy)
    {
        PlayerLevelController playerLevelScript = player.GetComponent<PlayerLevelController>();

        EnemyLevelController enemyLevelScript = enemy.GetComponent<EnemyLevelController>();
        EnemyLifeState enemyLifeState = enemy.GetComponent<EnemyLifeState>();

        int playerLevel = playerLevelScript.playerLevelCount;
        int enemyLevel = enemyLevelScript.enemyLevelCount;

        if (playerLevel > enemyLevel)
        {
            playerLevelScript.playerLevelCount += playerLevelIncreaseCount;
            PlayerLifeState.instance.CharacterSurvive(player);

            StartCoroutine(enemyLifeState.CharacterDead(enemy));

            return;
        }
        else if (playerLevel < enemyLevel) 
        {
            PlayerAnimations.instance.DeathAnimation();

            StartCoroutine(PlayerLifeState.instance.CharacterDead(player));

            enemy.GetComponent<EnemyLifeState>().CharacterSurvive(player);
        }
        return;

    }
}
