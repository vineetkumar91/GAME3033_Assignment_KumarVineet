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

    // Listener for health component
    public delegate void OnHealthInitializeEvent(HealthComponent healthComponent);

    // A static event for health initialization
    public static event OnHealthInitializeEvent OnHealthInitialized;

    // static invoke
    public static void Invoke_OnHealthInitialized(HealthComponent healthComponent)
    {
        // invoke health component
        OnHealthInitialized?.Invoke(healthComponent);
    }

}
