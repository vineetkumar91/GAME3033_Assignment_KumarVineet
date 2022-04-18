using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthInfoUI : MonoBehaviour
{
    // All TMP components for updating UI
    [Header("Health Info")]
    [SerializeField]
    private TextMeshProUGUI TMP_currentHP;
    [SerializeField]
    private TextMeshProUGUI TMP_maxHP;

    [Header("HP Bar")] 
    public Image HPBar;
    private float tempHP;
    public Image HPbar;
    private float lerpT = 0;
    public float LerpSpeed = 1f;

    private HealthComponent playerHealthComponent;

    private void OnEnable()
    {
        PlayerEvents.OnHealthInitialized += OnHealthInitialized;
    }

    private void OnDisable()
    {
        PlayerEvents.OnHealthInitialized -= OnHealthInitialized;
    }

    private void OnHealthInitialized(HealthComponent healthComponent)
    {
        playerHealthComponent = healthComponent;
    }

    // Start is called before the first frame update
    void Start()
    {
        HPBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TMP_currentHP.text = playerHealthComponent.currentHealth.ToString();
        TMP_maxHP.text = playerHealthComponent.maxHealth.ToString();

        if (playerHealthComponent.isUpdatingHPBar)
        {
            UpdateHPBar();
        }
    }


    /// <summary>
    /// Update the HP bar via Lerp
    /// </summary>
    private void UpdateHPBar()
    {
        // Get Lerp Time = Lerp Rate * deltatime
        lerpT += LerpSpeed * Time.deltaTime;

        // Get Lerp Value
        tempHP = Mathf.Lerp(playerHealthComponent.HPbeforeDamage, playerHealthComponent.currentHealth, lerpT);

        if (tempHP <= playerHealthComponent.maxHealth * 0.25)
        {
            HPbar.color = Color.red;
        }
        else
        {
            HPBar.color = Color.green;
        }

        // Start updating the fill amount with that lerp value / max HP
        HPbar.fillAmount = tempHP / playerHealthComponent.maxHealth;

        // If HP updated, stop calling this function and reset lerp time
        if (tempHP == playerHealthComponent.currentHealth)
        {
            playerHealthComponent.isUpdatingHPBar = false;
            lerpT = 0;
        }
    }
}
