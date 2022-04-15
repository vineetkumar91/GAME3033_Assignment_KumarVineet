using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI TMP_CurrentObjective;
    public List<string> Objectives;
    public List<GameObject> ObjectiveTriggers;
    public GameObject Truck = null;
    public int currentObjectiveNumber = 0;

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
        ActivateObjective(0);
    }

    /// <summary>
    /// Objective Trigger
    /// </summary>
    public void TriggerObjective(int objectiveNumber)
    {

        currentObjectiveNumber = objectiveNumber;

        TMP_CurrentObjective.text = Objectives[objectiveNumber];

        switch (objectiveNumber)
        {
            case 1:
                ActivateObjective(objectiveNumber);
                break;

            case 2:
                ActivateObjective(objectiveNumber);
                break;

            case 3:
                ObjectivePlantC4();
                break;

            case 4:
                ActivateObjective(objectiveNumber);
                break;

            case 5:
                ActivateObjective(objectiveNumber);
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Activates objective
    /// </summary>
    /// <param name="objectiveNumber"></param>
    public void ActivateObjective(int objectiveNumber)
    {
        foreach (var objective in ObjectiveTriggers)
        {
            objective.SetActive(false);
        }

        if (objectiveNumber < ObjectiveTriggers.Count)
        {
            ObjectiveTriggers[objectiveNumber].SetActive(true);
        }
    }


    /// <summary>
    /// Objective plant c4
    /// </summary>
    public void ObjectivePlantC4()
    {
        if (!GameManager.GetInstance().isC4Equipped)
        {
            GameManager.GetInstance().PromptUser("equipc4");
        }
        else
        {
            GameManager.GetInstance().PromptUser("plant");
            GameManager.GetInstance().isReadyToPlant = true;
        }
    }

    /// <summary>
    /// Not ready for planting
    /// </summary>
    public void NotReadyForPlanting()
    {
        GameManager.GetInstance().isReadyToPlant = false;
    }

    /// <summary>
    /// Plant C4
    /// </summary>
    /// <param name="playerController"></param>
    public void PlantC4(PlayerController playerController)
    {
        Truck.GetComponent<DetonateTruck>().StartDetonation(playerController);
    }
}
