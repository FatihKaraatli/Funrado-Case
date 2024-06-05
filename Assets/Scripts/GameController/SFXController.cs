using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour, ISFXController
{
    [field: SerializeField] public AudioSource audioSource { get; set ; }
    [field: SerializeField] public AudioClip attackSound { get; set ; }
    [field: SerializeField] public AudioClip deathSound { get; set; }
    [field: SerializeField] public AudioClip levelUpSound { get; set; }

    public static SFXController instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }

    public void PlayLevelUpSound()
    {
        audioSource.PlayOneShot(levelUpSound);
    }
}
