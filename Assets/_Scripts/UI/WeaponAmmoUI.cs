using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponAmmoUI : MonoBehaviour
{
    // All TMP components for updating UI
    [Header("Weapon Panel Ammo Updates")]
    [SerializeField] 
    private TextMeshProUGUI TMP_weaponName;
    [SerializeField]
    private TextMeshProUGUI TMP_currentBullets;
    [SerializeField]
    private TextMeshProUGUI TMP_totalBullets;


    [SerializeField] 
    private WeaponComponent weaponComponent;

    // "All things should be perfectly balanced" - Nick Falsitta
    private void Start()
    {
        // += :| wow.
        PlayerEvents.OnWeaponEquipped += OnWeaponEquipped;
    }

    private void OnDestroy()
    {
        
            PlayerEvents.OnWeaponEquipped -= OnWeaponEquipped;
        
    }

    /// <summary>
    /// Keep same signature as that event
    /// </summary>
    /// <param name="_weaponComponent"></param>
    void OnWeaponEquipped(WeaponComponent _weaponComponent)
    {
        Debug.Log("Something");
        weaponComponent = _weaponComponent;
    }

    // Update is called once per frame
    void Update()
    {
        if (!weaponComponent)
        {
            return;
        }
       
        
        TMP_weaponName.text = weaponComponent.weaponStats.weaponName;
        TMP_currentBullets.text = weaponComponent.weaponStats.bulletsInClip.ToString();
        TMP_totalBullets.text = weaponComponent.weaponStats.totalBullets.ToString();
        
    }
}
