using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEvents
{
    // Listener
    public delegate void MouseCursorEnable(bool enabled);

    // A static Event
    public static event MouseCursorEnable MouseCursorEnabled;

    // The static invoke of event
    public static void InvokeMouseCursorEnable(bool enabled)
    {
        // Invoke if enabled
        MouseCursorEnabled?.Invoke(enabled);
    }
}
