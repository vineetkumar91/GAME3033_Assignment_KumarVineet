using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    public AudioClip buttonClick;

    private static SFXManager _instance;
    public static SFXManager GetInstance()
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

    /// <summary>
    /// Play button clicks
    /// </summary>
    public void PlayButtonClick()
    {
        audioSource.volume = 0.7f;
        audioSource.clip = buttonClick;
        audioSource.Play();
    }
}
