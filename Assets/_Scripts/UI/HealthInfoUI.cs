using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthInfoUI : MonoBehaviour
{
    // All TMP components for updating UI
    [Header("Health Info")]
    [SerializeField]
    private TextMeshProUGUI TMP_currentHP;
    [SerializeField]
    private TextMeshProUGUI TMP_maxHP;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        TMP_currentHP.text = playerHealthComponent.CurrentHealth.ToString();
        TMP_maxHP.text = playerHealthComponent.MaxHealth.ToString();
    }
}
