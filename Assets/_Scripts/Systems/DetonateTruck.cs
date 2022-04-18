using System;
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
    private AudioSource audioSource;
    public AudioClip Plant;
    public AudioClip Tick;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Start Detonation
    /// </summary>
    public void StartDetonation(PlayerController playerController)
    {
        //Debug.Log("Starting Detonation");
        audioSource.clip = Plant;
        audioSource.Play();
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
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(delayForBlinking);
        audioSource.clip = Tick;
        audioSource.Play();
        blinkingLight.intensity = 10;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 0;
        yield return new WaitForSeconds(delayForBlinking);
        audioSource.Play();
        blinkingLight.intensity = 10;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 0;
        yield return new WaitForSeconds(delayForBlinking);
        audioSource.Play();
        blinkingLight.intensity = 10;
        yield return new WaitForSeconds(delayForBlinking);
        blinkingLight.intensity = 0;
        yield return new WaitForSeconds(delayForBlinking);
        audioSource.loop = true;
        audioSource.Play();
        blinkingLight.color = Color.red;
        blinkingLight.intensity = 10;
        yield return new WaitForSeconds(delayForExplosion);

        // Activate explosion
        explosionParticleFX.SetActive(true);

        // Activate physics
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(forcePoint.up * ForceValue, ForceMode.Impulse);
        audioSource.Stop();
        // Wait for 2 seconds before deactivating the explosion
        yield return new WaitForSeconds(2f);
        explosionParticleFX.SetActive(false);

        

        ObjectiveManager.GetInstance().TriggerObjective(4);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
