using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player Events to have static events, that take place for weapons
/// </summary>
public class PlayerEvents : MonoBehaviour
{
    // Listener
    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

    // A static Event
    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    // The static invoke of event
    public static void InvokeOnWeaponEquipped(WeaponComponent weaponComponent)
    {
        // Invoke if weapon equipped
        OnWeaponEquipped?.Invoke(weaponComponent);
    }
}

