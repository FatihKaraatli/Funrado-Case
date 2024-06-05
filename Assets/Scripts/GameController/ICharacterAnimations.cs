using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAnimations
{
    public Animator animator { get; set; }
    public void IdleAnimation();
    public void WalkAnimation();
    public void AttackAnimation();
    public void DeathAnimation();
}
