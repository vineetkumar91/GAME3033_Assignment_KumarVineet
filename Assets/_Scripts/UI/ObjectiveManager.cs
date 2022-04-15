using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI TMP_CurrentObjective;
    public List<string> Objectives;



    /// <summary>
    /// Singleton
    /// </summary>
    private static ObjectiveManager _instance;
    public static ObjectiveManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
        TMP_CurrentObjective.text = "";
    }

    /// <summary>
    /// Objective Trigger
    /// </summary>
    public void TriggerObjective(int objectiveNumber)
    {
        TMP_CurrentObjective.text = Objectives[objectiveNumber];
    }
}
