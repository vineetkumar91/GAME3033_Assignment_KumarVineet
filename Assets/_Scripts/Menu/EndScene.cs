using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public GameObject WinState;
    public GameObject LoseState;
    public TextMeshProUGUI TMP_GameStats;
    public Color winColor;
    public Color loseColor;

    private void Start()
    {
        // Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (Data.hasWon)
        {
            TMP_GameStats.text = "You Won!";
            TMP_GameStats.color = winColor;
            WinState.SetActive(true);
        }
        else
        {
            TMP_GameStats.text = "You Lost!";
            TMP_GameStats.color = loseColor;
            LoseState.SetActive(true);
        }
    }

    /// <summary>
    /// Start game button
    /// </summary>
    public void Button_OnStartGamePressed()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Main Menu button
    /// </summary>
    public void Button_OnMainMenuPressed()
    {
        SceneManager.LoadScene(0);
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
