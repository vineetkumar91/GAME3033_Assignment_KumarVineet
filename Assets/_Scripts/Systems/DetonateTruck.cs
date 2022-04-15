using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonateTruck : MonoBehaviour
{
    [Header("TruckReference")]
    public GameObject C4;
    public EquipmentScriptable C4ScriptableObject;
    public Light blinkingLight;
    public float delayForBlinking = 1;
    public float delayForExplosion = 1.5f;

    public Transform forcePoint;

    public float ForceValue = 200f;
    public bool isExecuteOnce = false;


    /// <summary>
    /// Start Detonation
    /// </summary>
    public void StartDetonation(PlayerController playerController)
    {
        Debug.Log("Starting Detonation");

        isExecuteOnce = true;
        playerController.weaponHolder.UnEquipC4();
        //GameManager.GetInstance().C4Equipment.DeleteC4Item(playerController);
        C4.SetActive(true);
        StartCoroutine(DetonationCoroutine());
        ObjectiveManager.GetInstance().TriggerObjective(4);
        
    }

    /// <summary>
    /// Coroutine 
    /// </summary>
    /// <returns></returns>
    IEnumerator DetonationCoroutine()
    {
        Debug.Log("In Coroutine");
        blinkingLight.color = Color.green;
        blinkingLight.intensity = 0;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 10;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 0;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 10;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 0;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 10;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 0;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.color = Color.red;
        blinkingLight.intensity = 10;
        yield return new WaitForSeconds(delayForExplosion);

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(forcePoint.up * ForceValue, ForceMode.Impulse);

        ObjectiveManager.GetInstance().TriggerObjective(4);

        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
