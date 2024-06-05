using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeState : MonoBehaviour , ICharacterLifeState
{
    public static PlayerLifeState instance { get; private set; }

    private bool isAlive = true;

    [Header("Effect")]
    public GameObject deathSkullEffect;

    [Header("Lost Countdown")]
    [SerializeField] private float time;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator CharacterDead(GameObject character)
    {
        isAlive = false;
        PlayerAnimations.instance.animator.SetBool("alive" , false);
        Instantiate(deathSkullEffect, character.transform.position, Quaternion.identity);

        SFXController.instance.PlayDeathSound();

        yield return new WaitForSeconds(time);

        GameEnd.instance.PlayerLost();
    }

    public void CharacterSurvive(GameObject character)
    {
        PlayerLevelController playerLevelScript = character.GetComponent<PlayerLevelController>();
        PlayerAnimations playerAnimations = character.GetComponent<PlayerAnimations>();

        SFXController.instance.PlayAttackSound();

        playerLevelScript.SetLevel(0);
        playerAnimations.AttackAnimation();
    }

    public bool GetLifeState()
    {
        return isAlive;
    }

}
