using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour //Singleton<GameManager>
{

    public bool cursorActive = true;

    // Lazy singleton for GM temporarily
    private static GameManager Instance;

    [Header("Objectives")]
    public int objectiveNumber = 0;

    [Header("Prompts")] 
    public TextMeshProUGUI TMP_Prompts;

    public Dictionary<string, string> promptsDictionary;
    public List<string> promptKey;
    public List<string> promptValue;
    private bool isPromptOn = false;
    private IEnumerator promptCoroutine;
    public float promptDelay = 4f;
    private string clear = "clear";

    [Header("C4 Equipped")] 
    public bool isC4Equipped = false;
    public bool isReadyToPlant = false;
    public EquipmentScriptable C4Equipment;

    public bool isPaused = false;

    [Header("Player")] 
    public bool isPlayerDead = false;
    public Image fadeToBlack;
    public float duration = 2f;
    private bool executeOnce = false;

    [Header("Timer")]
    public TextMeshProUGUI TMP_Timer;
    public float timer = 0f;
    public float timerCounter = 0f;
    public float maxTime = 0f;

    public TextMeshProUGUI TMP_ZombieWaveTimerLabel;
    public TextMeshProUGUI TMP_ZombieTimer;

    [Header("Timer")] 
    public int score;
    public TextMeshProUGUI TMP_Score;

    public static GameManager GetInstance()
    {
        return Instance;
    }

    public void Awake()
    {
        Instance = this;
    }


    /// <summary>
    /// Game manager update function
    /// </summary>
    private void Update()
    {
        if (!isPaused && !isPlayerDead)
        {
            // Time runs out
            if (maxTime <= 0f)
            {
                maxTime = 0f;
                if (!executeOnce)
                {
                    executeOnce = true;
                    Data.hasWon = false;
                    StartCoroutine(FadeToBlackCoroutine());
                    TMP_Timer.text = "0:00";
                }
            }
            else
            {
                maxTime -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(maxTime / 60f);
                int seconds = Mathf.FloorToInt(maxTime - minutes * 60);
                string time = string.Format("{0:0}:{1:00}", minutes, seconds);
                TMP_Timer.text = time;
            }

            // Zombie timer
            if (maxTime <= 130f && maxTime > 120f)
            {
                TMP_ZombieWaveTimerLabel.text = "Wave 2 In:";
                TMP_ZombieTimer.text = ((int)(maxTime - 120f)).ToString();
            }
            else if (maxTime <= 70f && maxTime > 60f)
            {
                TMP_ZombieWaveTimerLabel.text = "Wave 3 In:";
                TMP_ZombieTimer.text = ((int)(maxTime - 60f)).ToString();
            }
            else
            {
                TMP_ZombieWaveTimerLabel.text = "";
                TMP_ZombieTimer.text = "";
            }
        }
    }



    /// <summary>
    /// Score
    /// </summary>
    /// <param name="addScore"></param>
    public void AddScore(int addScore)
    {
        score += addScore;
        Data.score = score;
        TMP_Score.text = score.ToString();
    }

    private void Start()
    {
        ObjectiveManager.GetInstance().TriggerObjective(objectiveNumber);

        // Prompts
        // Load dictionary
        promptsDictionary = new Dictionary<string, string>();
        for (int i = 0; i < promptKey.Count; i++)
        {
            promptsDictionary.Add(promptKey[i],promptValue[i]);
        }

        promptCoroutine = ShowPromptCoroutine(clear);
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


    /// <summary>
    /// Function to give prompts to user
    /// </summary>
    public void PromptUser(string key)
    {
        if (!isPromptOn)
        {
            isPromptOn = true;
            promptCoroutine = ShowPromptCoroutine(key);
            StartCoroutine(promptCoroutine);
        }
        else
        {
            isPromptOn = true;
            StopCoroutine(promptCoroutine);
            promptCoroutine = ShowPromptCoroutine(key);
            StartCoroutine(promptCoroutine);
        }
    }

    /// <summary>
    /// Coroutine of prompt
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    IEnumerator ShowPromptCoroutine(string key)
    {
        // display prompt
        TMP_Prompts.text = promptsDictionary[key];

        // delay
        yield return new WaitForSeconds(promptDelay);

        // clear
        TMP_Prompts.text = promptsDictionary[clear];
        StopCoroutine(promptCoroutine);
        isPromptOn = false;
    }

    /// <summary>
    /// Start fade to black
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeToBlackCoroutine()
    {

        yield return new WaitForSeconds(2f);
        float timer = 0.0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;

            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, Mathf.SmoothStep(0.0f, 1f, timer / duration));

            yield return new WaitForEndOfFrame();
        }

        fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, 1f);

        SceneManager.LoadScene(2);
    }
}
