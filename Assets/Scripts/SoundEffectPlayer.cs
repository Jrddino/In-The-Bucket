using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sfx = new AudioClip[7];
    public AudioClip explosion;
    public AudioClip scream;

    public void PlayRandomClip()
    {
        int randomIndex = Random.Range(0, sfx.Length - 1);
        audioSource.clip = sfx[randomIndex];
        audioSource.Play();
    }

    public void PlayExplosion()
    {
        audioSource.clip = explosion;
        audioSource.Play();
    }

    public void PlayScream()
    {
        audioSource.clip = scream;
        audioSource.Play();
    }
}
