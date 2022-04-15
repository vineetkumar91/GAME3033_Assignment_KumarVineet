using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour //Singleton<GameManager>
{

    public bool cursorActive = true;

    // Lazy singleton for GM temporarily
    private static GameManager Instance;

    public int objectiveNumber = 0;

    public static GameManager GetInstance()
    {
        return Instance;
    }

    public void Awake()
    {
        Instance = this;

        ObjectiveManager.GetInstance().TriggerObjective(objectiveNumber);
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
            Debug.Log("Visible");
        }
        else
        {
            cursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Not Visible");
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
