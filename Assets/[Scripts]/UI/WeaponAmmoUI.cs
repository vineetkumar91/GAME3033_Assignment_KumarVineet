using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Ammo and C4 Panels")] 
    public GameObject AmmoPanel;
    public GameObject C4Panel;
    public Color zeroAmmo;
    public Color fullAmmo;

    [SerializeField]
    private TextMeshProUGUI TMP_slashSign;

    // "All things should be perfectly balanced" - Nick Falsitta
    private void Start()
    {
        // += :| wow.
        PlayerEvents.OnWeaponEquipped += OnWeaponEquipped;
        PlayerEvents.OnC4Equipped += OnEquipC4;
        PlayerEvents.OnUnequipWeapon += OnUnquipWeapons;

        AmmoPanel.SetActive(false);
        C4Panel.SetActive(false);
    }

    private void OnDestroy()
    {
        
        PlayerEvents.OnWeaponEquipped -= OnWeaponEquipped;
        PlayerEvents.OnC4Equipped -= OnEquipC4;
        PlayerEvents.OnUnequipWeapon -= OnUnquipWeapons;

    }

    /// <summary>
    /// Keep same signature as that event
    /// </summary>
    /// <param name="_weaponComponent"></param>
    void OnWeaponEquipped(WeaponComponent _weaponComponent)
    {
        weaponComponent = _weaponComponent;
        AmmoPanel.SetActive(true);
        C4Panel.SetActive(false);
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

        AmmoPanel.GetComponent<Image>().color = Color.Lerp(zeroAmmo, fullAmmo, (float)weaponComponent.weaponStats.bulletsInClip / (float)weaponComponent.weaponStats.clipSize);

    }

    /// <summary>
    /// C4 Equipped function
    /// </summary>
    public void OnEquipC4()
    {
        TMP_weaponName.text = "C-4";
        AmmoPanel.SetActive(false);
        C4Panel.SetActive(true);
    }

    /// <summary>
    /// Unequip weapon
    /// </summary>
    public void OnUnquipWeapons()
    {
        TMP_weaponName.text = "No Weapon Equipped";
        AmmoPanel.SetActive(false);
        C4Panel.SetActive(false);
    }
}
