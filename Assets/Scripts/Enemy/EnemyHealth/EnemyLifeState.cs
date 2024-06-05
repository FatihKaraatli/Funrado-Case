using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyLifeState : MonoBehaviour , ICharacterLifeState
{

    [Header("Effect")]
    public GameObject deathPofEffect;
    public GameObject deathSkullEffect;
    public GameObject scareEffect;


    public IEnumerator CharacterDead(GameObject character)
    {
        EnemyAnimation enemyAnimations = character.GetComponent<EnemyAnimation>();

        enemyAnimations.animator.SetBool("alive", false);
        enemyAnimations.DeathAnimation();

        SFXController.instance.PlayDeathSound();

        yield return new WaitForSeconds(0.3f);

        Instantiate(deathPofEffect, character.transform.position, Quaternion.identity);
        Instantiate(deathSkullEffect, character.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }

    public void CharacterSurvive(GameObject player)
    {
        this.gameObject.GetComponent<EnemyAttack>().EnemyAttacking(player);
    }

    public void EnemyScared()
    {
        Instantiate(scareEffect, transform.position + (Vector3.up * 2), Quaternion.identity);
    }
}
