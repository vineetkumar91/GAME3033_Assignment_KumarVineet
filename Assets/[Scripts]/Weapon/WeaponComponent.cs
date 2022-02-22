using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None,
    Pistol,
    MachineGun
}

public enum WeaponFiringPattern
{
    SemiAuto, 
    FullAuto, 
    ThreeShotBurst, 
    FiveShotBurst
}


// All the stats of a weapon, clip size, bullets in clip, fire rate, distance
[System.Serializable]
public struct WeaponStats
{
    WeaponType weaponType;
    public string weaponName;
    public float damage;
    public int bulletsInClip;
    public int clipSize;
    public float fireStartDelay;
    public float fireRate;
    public float fireDistance;
    public bool repeating;
    public LayerMask weaponHitLayers;
    public WeaponFiringPattern firingPattern;
    public int totalBullets;
}
public class WeaponComponent : MonoBehaviour
{
    public Transform gripLocation;

    protected WeaponHolder weaponHolder;

    [SerializeField]
    public WeaponStats weaponStats;

    public bool isFiring = false;
    public bool isReloading = false;

    protected Camera mainCamera;

    [Header("Particle FX")]
    [SerializeField]
    protected ParticleSystem firingEffect;
    protected Transform firingEffectLocation;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(WeaponHolder weaponHolder)
    {
        this.weaponHolder = weaponHolder;
    }

    public virtual void StartFiringWeapon()
    {
        isFiring = true;

        if (weaponStats.repeating)
        {
            InvokeRepeating(nameof(FireWeapon), weaponStats.fireStartDelay, weaponStats.fireRate);
        }
        else
        {
            FireWeapon();
        }
    }

    public virtual void StopFiringWeapon()
    {
        isFiring = false;
        CancelInvoke(nameof(FireWeapon));

        // particle effect
        if (firingEffect)
        {
            firingEffect.Stop();
        }
    }

    protected virtual void FireWeapon()
    {
        weaponStats.bulletsInClip--;
    }

    public virtual void StartReloading()
    {
        isReloading = true;
        ReloadWeapon();
    }

    private void ReloadWeapon()
    {
        // Stop particle effects
        // particle effect
        if (firingEffect)
        {
            firingEffect.Stop();
        }

        int bulletsToReload = weaponStats.clipSize - weaponStats.totalBullets;

        // less than 0
        if (bulletsToReload < 0)
        {
            // put max clip size in bullets, that is, 30 bullets
            weaponStats.bulletsInClip = weaponStats.clipSize;

            // subtract the bullets of clip size (30) - 500 <--
            weaponStats.totalBullets -= weaponStats.clipSize;

        }
        else
        {
            // else the size is something like 30 - (30-n), less than clip size
            weaponStats.bulletsInClip = weaponStats.totalBullets;

            // and set total bullets, cause its finished
            weaponStats.totalBullets = 0;
        }
    }

    public virtual void StopReloading()
    {
        isReloading = false;
    }
}
