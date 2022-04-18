using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ZombieSound
{
    BASIC,
    BASIC2,
    FEMALE,
    ATTACK
}

public class ZombieSounds : MonoBehaviour
{

    private AudioSource audioSource;
    public List<AudioClip> audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    /// <summary>
    /// Play Zombie sounds
    /// </summary>
    /// <param name="sound"></param>
    public void PlaySound(ZombieSound sound)
    {
        audioSource.clip = audioClip[(int)sound];
        audioSource.Play();
    }

}
