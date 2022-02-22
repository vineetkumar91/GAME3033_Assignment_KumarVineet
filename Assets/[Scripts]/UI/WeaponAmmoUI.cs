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

    [Header("Weapon Component")]
    [SerializeField]
    private WeaponComponent weaponComponent;


    // On Enable
    private void OnEnable()
    {
        PlayerEvents.OnWeaponEquipped += OnWeaponEqupped;
    }

    // On Disable
    private void OnDisable()
    {
        
        PlayerEvents.OnWeaponEquipped -= OnWeaponEqupped;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!weaponComponent)
        {
            return;
        }
        else
        {
            TMP_weaponName.text = weaponComponent.weaponStats.weaponName;
            TMP_currentBullets.text = weaponComponent.weaponStats.bulletsInClip.ToString();
            TMP_totalBullets.text = weaponComponent.weaponStats.totalBullets.ToString();
        }
    }

    /// <summary>
    /// Keep same signature as that event
    /// </summary>
    /// <param name="_weaponComponent">returns weapon component</param>
    void OnWeaponEqupped(WeaponComponent _weaponComponent)
    {
        weaponComponent = _weaponComponent;
    }
}
