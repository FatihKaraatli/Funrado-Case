using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISFXController
{
    public AudioSource audioSource { get; set; }
    public AudioClip attackSound { get; set; }
    public AudioClip deathSound { get; set; }
    public AudioClip levelUpSound { get; set; }

    public void PlayAttackSound();
    public void PlayDeathSound();
    public void PlayLevelUpSound();
}
