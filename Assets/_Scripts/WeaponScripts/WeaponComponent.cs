using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 2nd Feb
public enum WeaponType
{
    None,
    Pistol,
    MachineGun,
    Launcher,
    TOTAL_TYPES
}

public enum WeaponFiringPattern
{
    SemiAuto, FullAuto, ThreeShotBurst, FiveShotBurst
}

// 2nd Feb
// All the stats of a weapon, clip size, bullets in clip, fire rate, distance et cetera
[System.Serializable]
public struct WeaponStats
{
    public WeaponType weaponType;
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
    public int bulletsRemaining;
    public Image weaponIcon;
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

    // Feb 9th
    [Header("Particle FX")]
    [SerializeField]
    protected ParticleSystem firingEffect;
    protected Transform firingEffectLocation;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        //firingEffect.gameObject.transform.parent = firingEffectLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Initialize the weapon component
    /// 2nd Feb
    /// </summary>
    /// <param name="weaponHolder"></param>
    public void Initialize(WeaponHolder weaponHolder, WeaponScriptable weaponScriptable)
    {
        this.weaponHolder = weaponHolder;

        if (weaponScriptable)
        {
            weaponStats = weaponScriptable.weaponStats;
        }

    }


    // 2nd feb - weapon functionality 
    /// <summary>
    /// Repeating Weapon
    /// </summary>
    public virtual void StartFiringWeapon()
    {
        isFiring = true;

        if (weaponStats.repeating)
        {
            InvokeRepeating(nameof(FireWeapon),weaponStats.fireStartDelay, weaponStats.fireRate);
        }
        else
        {
            FireWeapon();
        }
    }

    /// <summary>
    /// Stop Firing Weapon
    /// </summary>
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
        //Debug.Log("Firing Weapon!!!");
        weaponStats.bulletsInClip--;
    }


    // Deal with ammo counts & particle effects if shooting
    public virtual void StartReloading()
    {
        isReloading = true;
        ReloadWeapon();
    }


    public virtual void StopReloading()
    {
        isReloading = false;
    }

    protected virtual void ReloadWeapon()
    {
        // particle effect
        if (firingEffect)
        {
            firingEffect.Stop();
        }

        // if Firing effect, "hide" it here..

        // Example of value of AK to understand logic...
        // get something like -470

        // 23 March - Fix
        // Update the actual bullets to reload, bullets clip capacity - clips remaining

        int bulletsToReload = weaponStats.totalBullets - (weaponStats.clipSize - weaponStats.bulletsInClip);

        // greater than 0
        if (bulletsToReload > 0)
        {
            //// put max clip size in bullets, that is, 30 bullets
            //weaponStats.bulletsInClip = weaponStats.clipSize;
            //
            //// subtract the bullets of clip size (30) - 500 <--
            //weaponStats.totalBullets -= weaponStats.clipSize;

            // 23 March - Fix
            weaponStats.totalBullets = bulletsToReload;

            weaponStats.bulletsInClip = weaponStats.clipSize;

        }
        else
        {
            //// else the size is something like 30 - (30-n), less than clip size
            //weaponStats.bulletsInClip = weaponStats.totalBullets;
            //
            //// and set total bullets, cause its finished
            //weaponStats.totalBullets = 0;


            // 23 March - Fix
            weaponStats.bulletsInClip += weaponStats.totalBullets;

            weaponStats.totalBullets = 0;
        }
    }
}
