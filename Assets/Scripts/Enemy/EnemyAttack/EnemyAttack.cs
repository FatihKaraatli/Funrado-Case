using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttack : MonoBehaviour
{
    [Header("RotateObject")]
    public Transform enemy;

    [Header("Speed")]
    public float attackSpeed;

    private bool shouldMove = false;

    private GameObject playerObj;

    private void Update()
    {
        if (shouldMove)
        {
            float distance = Vector2.Distance(playerObj.transform.position , transform.position);
            if (distance > 0.5f)
            {
                enemy.LookAt(playerObj.transform.position);

                Vector2 direction = transform.position - playerObj.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, playerObj.transform.position, attackSpeed * Time.deltaTime);
            }
            else
            {
                shouldMove = false;
            }
        }
    }
    public void EnemyAttacking(GameObject player)
    {
        this.gameObject.GetComponent<EnemyPatrol>().SetPatrol();
        playerObj = player; 
        shouldMove = true;  
        this.gameObject.GetComponent<EnemyAnimation>().AttackAnimation();

        SFXController.instance.PlayAttackSound();
    }
}
