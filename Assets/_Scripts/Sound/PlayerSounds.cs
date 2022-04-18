using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSFX
{
    WeaponFire,
    GrenadeLaunch,
    GrenadeExplode,
    Hurt,
    Dead,
    Reload,
    Medikit
}

public class PlayerSounds : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public List<AudioClip> audioClip;

    private static PlayerSounds _instance;
    public static PlayerSounds GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

}
