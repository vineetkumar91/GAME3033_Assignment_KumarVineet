using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveTriggerComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.name.Equals("Objective0"))
            {
                ObjectiveManager.GetInstance().TriggerObjective(1);
            }
            else if (gameObject.name.Equals("Objective1"))
            {
                ObjectiveManager.GetInstance().TriggerObjective(2);
            }
            else if (gameObject.name.Equals("Objective2"))
            {
                ObjectiveManager.GetInstance().ObjectivePlantC4();
            }
            else if (gameObject.name.Equals("Objective4"))
            {
                Data.hasWon = true;
                SceneManager.LoadScene((int)Scenes.END_SCENE);
            }
        }
    }

    /// <summary>
    /// Trigger exit needed
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.name.Equals("Objective2"))
            {
                ObjectiveManager.GetInstance().NotReadyForPlanting();
            }
        }
    }
}
