using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesMgr : MonoBehaviour
{

    private static ScenesMgr _instance;

    public static ScenesMgr GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    public enum Scenes
    {
        MAIN_MENU,
        PLAY_SCENE,
        END_SCENE
    }

    /// <summary>
    /// Change to main menu scene
    /// </summary>
    public void Button_MainMenu()
    {
        SceneManager.LoadScene((int)Scenes.MAIN_MENU);
    }


    /// <summary>
    /// Change to play menu scene
    /// </summary>
    public void Button_PlayScene()
    {
        SceneManager.LoadScene((int)Scenes.PLAY_SCENE);
    }


    /// <summary>
    /// Change to end scene
    /// </summary>
    public void EndScene()
    {
        SceneManager.LoadScene((int)Scenes.END_SCENE);
    }


    /// <summary>
    /// Quit Game
    /// </summary>
    public void Button_QuitGame()
    {
        Application.Quit();

        #region EditorQuit
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#endif


        #endregion
    }
}
