using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{

    [Header("Audio")]
    private AudioSource audioSource;
    public List<AudioClip> audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip[0];
        audioSource.Play();
    }
}
