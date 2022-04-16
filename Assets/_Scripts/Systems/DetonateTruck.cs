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
    public GameObject explosionParticleFX;


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
        ObjectiveManager.GetInstance().TriggerObjective(3);
        
    }

    /// <summary>
    /// Coroutine 
    /// </summary>
    /// <returns></returns>
    IEnumerator DetonationCoroutine()
    {

        // Blinking light effect
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

        // Activate explosion
        explosionParticleFX.SetActive(true);

        // Activate physics
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(forcePoint.up * ForceValue, ForceMode.Impulse);
        
        // Wait for 2 seconds before deactivating the explosion
        yield return new WaitForSeconds(2f);
        explosionParticleFX.SetActive(false);
        
        ObjectiveManager.GetInstance().TriggerObjective(4);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
