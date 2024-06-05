using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour , ICharacterAnimations
{
    [field: SerializeField] public Animator animator { get; set; }

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
        animator.SetFloat("walk", 0);
    }

    public void WalkAnimation()
    {
        animator.SetFloat("walk", 5);
    }
}
