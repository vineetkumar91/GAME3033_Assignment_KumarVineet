using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool cursorActive = true;

    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    public void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != (int)ScenesMgr.Scenes.PLAY_SCENE)
        {
            EnableCursor(true);
        }
        else
        {
            EnableCursor(false);
        }
        _instance = this;
    }

    /// <summary>
    /// Enables cursor with the event
    /// makes it visible and locked, or otherwise opposite of that
    /// </summary>
    /// <param name="enable"></param>
    void EnableCursor(bool enable)
    {
        if (enable)
        {
            cursorActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            cursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    // On Enable / Disable events listener 
    public void OnEnable()
    {
        AppEvents.MouseCursorEnabled += EnableCursor;
    }


    public void OnDisable()
    {
        AppEvents.MouseCursorEnabled -= EnableCursor;
    }
}
