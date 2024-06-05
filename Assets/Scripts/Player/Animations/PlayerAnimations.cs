using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour , ICharacterAnimations
{
    [field: SerializeField]  public Animator animator { get ; set ; }

    public static PlayerAnimations instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("attack");
    }

    public void DeathAnimation()
    {
        animator.SetTrigger("death");
    }

    public void IdleAnimation()
    {
        animator.SetFloat("walk" , 0);
    }

    public void WalkAnimation()
    {
        animator.SetFloat("walk", 5);
    }
}
