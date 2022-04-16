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

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject InstructionsPanel;
    public GameObject CreditsPanel;


    private void Start()
    {
        MenuPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    /// <summary>
    /// Start game button
    /// </summary>
    public void Button_OnStartGamePressed()
    {
        Data.Reset();
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Instructions button
    /// </summary>
    public void Button_OnInstructionsPressed()
    {
        MenuPanel.SetActive(false);
        InstructionsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    /// <summary>
    /// Credits button
    /// </summary>
    public void Button_OnCreditsPressed()
    {
        MenuPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    /// <summary>
    /// Exit button
    /// </summary>
    public void Button_OnExitPressed()
    {
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
        MenuPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
}
