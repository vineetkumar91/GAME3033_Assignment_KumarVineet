using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scenes
/// </summary>
public enum Scenes
{
    START_SCENE,
    MENU_SCENE,
    GAME_SCENE,
    END_SCENE,
    TOTAL_SCENES
}

/// <summary>
/// Buttons
/// </summary>
public enum Buttons
{
    START_BUTTON,
    INSTRUCTIONS_BUTTON,
    CREDITS_BUTTON,
    BACK_BUTTON,
    EXIT_BUTTON,
    RESUME_BUTTON,
    MENU_BUTTON,
    TOTAL_BUTTONS
}


public enum MenuAudioClips
{
    ButtonClick,
}

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject InstructionsPanel;
    public GameObject CreditsPanel;

    [Header("Audio")] 
    private AudioSource audioSource;
    public List<AudioClip> audioClip;

    private void Start()
    {
        MenuPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Start game button
    /// </summary>
    public void Button_OnStartGamePressed()
    {
        audioSource.clip = audioClip[(int)MenuAudioClips.ButtonClick];
        audioSource.Play();
        Data.Reset();
        SceneManager.LoadScene((int)Scenes.GAME_SCENE);
    }

    /// <summary>
    /// Instructions button
    /// </summary>
    public void Button_OnInstructionsPressed()
    {
        audioSource.clip = audioClip[(int)MenuAudioClips.ButtonClick];
        audioSource.Play();
        MenuPanel.SetActive(false);
        InstructionsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    /// <summary>
    /// Credits button
    /// </summary>
    public void Button_OnCreditsPressed()
    {
        audioSource.clip = audioClip[(int)MenuAudioClips.ButtonClick];
        audioSource.Play();
        MenuPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    /// <summary>
    /// Exit button
    /// </summary>
    public void Button_OnExitPressed()
    {
        audioSource.clip = audioClip[(int)MenuAudioClips.ButtonClick];
        audioSource.Play();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    /// <summary>
    /// Back button
    /// </summary>
    public void Button_OnBackButtonPressed()
    {
        audioSource.clip = audioClip[(int)MenuAudioClips.ButtonClick];
        audioSource.Play();
        MenuPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
}
