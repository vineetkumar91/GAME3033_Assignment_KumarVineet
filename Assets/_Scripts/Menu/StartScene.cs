using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private string gameTitle = "TRIADS OF HELL";
    public TextMeshProUGUI TMP_Title;
    public float secondsPerCharacter = 0.3f;
    public TextMeshProUGUI TMP_PressAnyKey;
    public bool isNarrationOn = false;
    public float duration;
    Color whiteOpaque = Color.white;
    Color whiteTransparent = Color.white;
    private bool m_ButtonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        isNarrationOn = true;
        StartCoroutine(AnimateTextCoroutine(gameTitle));
        whiteTransparent = new Color(1f, 1f, 1f, 0f);
        TMP_PressAnyKey.color = whiteTransparent;
    }

    private void Update()
    {
        if (m_ButtonPressed && !isNarrationOn)
        {
            StopAllCoroutines();
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator AnimateTextCoroutine(string message)
    {
        TMP_Title.text = "";

        for (int currentChar = 0; currentChar < message.Length; currentChar++)
        {
            TMP_Title.text += message[currentChar];
            yield return new WaitForSeconds(secondsPerCharacter);
        }
        
        isNarrationOn = false;
        StartCoroutine(BlinkAnimation());

        // input system event for detecting any key press
        // https://forum.unity.com/threads/check-if-any-key-is-pressed.763751/
        InputSystem.onEvent +=
            (eventPtr, device) =>
            {
                if (!eventPtr.IsA<StateEvent>() && !eventPtr.IsA<DeltaStateEvent>())
                    return;
                var controls = device.allControls;
                var buttonPressPoint = InputSystem.settings.defaultButtonPressPoint;
                for (var i = 0; i < controls.Count; ++i)
                {
                    var control = controls[i] as ButtonControl;
                    if (control == null || control.synthetic || control.noisy)
                        continue;
                    if (control.ReadValueFromEvent(eventPtr, out var value) && value >= buttonPressPoint)
                    {
                        m_ButtonPressed = true;
                        break;
                    }
                }
            };
    }

    /// <summary>
    /// Blinking animation
    /// </summary>
    /// <returns></returns>
    IEnumerator BlinkAnimation()
    {
        TMP_PressAnyKey.color = whiteOpaque;

        while (true)
        {
            float timer = 0.0f;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                TMP_PressAnyKey.color = Color.Lerp(whiteOpaque, whiteTransparent, timer / duration);

                yield return new WaitForEndOfFrame();
            }

            TMP_PressAnyKey.color = whiteTransparent;

            timer = 0.0f;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                TMP_PressAnyKey.color = Color.Lerp(whiteTransparent, whiteOpaque, timer / duration);

                yield return new WaitForEndOfFrame();
            }

            TMP_PressAnyKey.color = whiteOpaque;
        }
    }


}
