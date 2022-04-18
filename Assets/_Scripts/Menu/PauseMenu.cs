using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    // Singleton
    private static PauseMenu _instance;

    public static PauseMenu GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// Enable pause panel
    /// </summary>
    public void EnablePausePanel(bool activate)
    {
        if (activate)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pausePanel.SetActive(true);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }

    /// <summary>
    /// Resume button
    /// </summary>
    public void Button_OnResumePressed()
    {
        Time.timeScale = 1f;
        GameManager.GetInstance().isPaused = false;
        EnablePausePanel(false);
    }

    /// <summary>
    /// Restart game button
    /// </summary>
    public void Button_OnRestartGamePressed()
    {
        Time.timeScale = 1f;
        Data.Reset();
        SceneManager.LoadScene((int)Scenes.GAME_SCENE);
    }

    /// <summary>
    /// Main Menu button
    /// </summary>
    public void Button_OnMainMenuPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene((int)Scenes.MENU_SCENE);
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
}
