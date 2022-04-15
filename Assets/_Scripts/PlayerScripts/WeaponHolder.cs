///----------------------------------------------------------------------------------
///   Endless Horde Zombie Shooter
///   WeaponHolder.cs
///   Author            : Vineet Kumar
///   Last Modified     : 2022/02/02
///   Description       : Overall Weapon controls and Animations
///   Revision History  : 2nd ed. Adjusting animation of grip
///----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum AnimatorOverrides
{
    WITHOUT_WEAPON,
    WITH_WEAPON
}
public class WeaponHolder : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    private GameObject WeaponToSpawn;


    public PlayerController _playerController;

    private Sprite crosshairImage;

    public Animator animator;
    [SerializeField]
    private GameObject WeaponScoketLocation;

    // 2nd Feb
    [SerializeField]
    private Transform GripIKScoketLocation;
    private WeaponComponent equippedWeapon;

    public GameObject C4;

    public readonly int isFiringHash = Animator.StringToHash("IsFiring");
    public readonly int isReloadingHash = Animator.StringToHash("IsReloading");


    private bool wasFiring = false;
    private bool firingPressed = false;

    GameObject spawnedWeapon;
    public Dictionary<WeaponType, WeaponStats> weaponAmmoDictionary;

    // Animator overrides
    public AnimatorOverrideController[] jamesAnimatorOverrideControllers;

    [SerializeField]
    private WeaponScriptable startWeapon;

    public WeaponComponent GetEquippedWeapon => equippedWeapon;

    


    // Start is called before the first frame update
    void Start()
    {
       //spawnedWeapon = Instantiate(WeaponToSpawn, WeaponScoketLocation.transform.position,
       //    WeaponScoketLocation.transform.rotation, WeaponScoketLocation.transform);

        animator = GetComponent<Animator>();
        weaponAmmoDictionary = new Dictionary<WeaponType, WeaponStats>();
        _playerController = GetComponent<PlayerController>();

        animator.runtimeAnimatorController = jamesAnimatorOverrideControllers[(int)AnimatorOverrides.WITHOUT_WEAPON];

        // 2nd Feb
        //equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
        //equippedWeapon.Initialize(this);

        // Events...
        //PlayerEvents.InvokeOnWeaponEquipped(equippedWeapon);
        /// Events


        //GripIKScoketLocation = equippedWeapon.gripLocation;



        // Adds Start Weapon        
        //_playerController.inventory.AddItem(startWeapon, 1);

        weaponAmmoDictionary.Add(startWeapon.weaponStats.weaponType, startWeapon.weaponStats);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Animator IK
    /// </summary>
    /// <param name="layerIndex"></param>
    private void OnAnimatorIK(int layerIndex)
    {
        if (equippedWeapon)
        {
            if (equippedWeapon.weaponStats.weaponName.Equals("AK-47"))
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, equippedWeapon.gripLocation.position);
            }
        }
    }

    public void OnFire(InputValue value)
    {
        // Call the actual fire weapon from Weapon Holder here

        firingPressed = value.isPressed;
        

        if (firingPressed)
        {
            StartFiring();
        }
        else
        {
            StopFiring();
        }
    }

    // 2nd Feb
    // Reload
    public void OnReload(InputValue value)
    {
        _playerController.isReloading = value.isPressed;
        StartReloading();
    }

    // Start Firing weapon
    private void StartFiring()
    {

        if (!equippedWeapon) return;

        if (equippedWeapon.weaponStats.bulletsInClip <= 0)
        {
            StartReloading();
            return;
        }

        _playerController.isFiring = true;
        animator.SetBool(isFiringHash, true);
        equippedWeapon.StartFiringWeapon();
    }

    // Stop Firing weapon
    private void StopFiring()
    {
        if (!equippedWeapon) return;

        _playerController.isFiring = false;
        animator.SetBool(isFiringHash,false);
        equippedWeapon.StopFiringWeapon();
    }

    // Reload weapon
    public void StartReloading()
    {
        if (!equippedWeapon) return;

        if (equippedWeapon.isReloading ||
            equippedWeapon.weaponStats.bulletsInClip == equippedWeapon.weaponStats.clipSize)
        {
            return;
        }

        // If Reloading starts, stop firing
        if (_playerController.isFiring)
        {
            StopFiring();
        }

        // If out of TOTAL bullets, no point of reloading
        if (equippedWeapon.weaponStats.totalBullets <= 0)
        {
            return;
        }

        // Animator
        animator.SetBool(isReloadingHash, true);
        equippedWeapon.StartReloading();

        InvokeRepeating(nameof(StopReloading), 0, 0.1f);
    }


    // Stop Reloading Weapon
    public void StopReloading()
    {
        if (!equippedWeapon) return;

        if (animator.GetBool(isReloadingHash))
        {
            return;
        }

        // Stop reloading 
        _playerController.isReloading = false;
        // Call the weapon's stop reloading
        equippedWeapon.StopReloading();
        // Start animation
        animator.SetBool(isReloadingHash, false);

        // stop reloading invoke is stopped
        CancelInvoke(nameof(StopReloading));
    }


    /// <summary>
    /// Equip weapon
    /// </summary>
    /// <param name="weaponScriptable"></param>
    public void EquipWeapon(WeaponScriptable weaponScriptable)
    {
        if (!weaponScriptable) return;

        spawnedWeapon = Instantiate(weaponScriptable.itemPrefab, WeaponScoketLocation.transform.position, WeaponScoketLocation.transform.rotation, WeaponScoketLocation.transform);

        if (!spawnedWeapon) return;

        equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();

        if (!equippedWeapon) return;

        equippedWeapon.Initialize(this, weaponScriptable);
        if (weaponAmmoDictionary.ContainsKey(equippedWeapon.weaponStats.weaponType))
        {
            equippedWeapon.weaponStats = weaponAmmoDictionary[equippedWeapon.weaponStats.weaponType];
        }


        // Set Animator override
        animator.runtimeAnimatorController = jamesAnimatorOverrideControllers[(int)AnimatorOverrides.WITH_WEAPON];

        PlayerEvents.InvokeOnWeaponEquipped(equippedWeapon);
    }


    /// <summary>
    /// Unequip weapon
    /// </summary>
    public void UnEquipWeapon()
    {
        if (!equippedWeapon) return;
        if (weaponAmmoDictionary.ContainsKey(equippedWeapon.weaponStats.weaponType))
        {
            weaponAmmoDictionary[equippedWeapon.weaponStats.weaponType] = equippedWeapon.weaponStats;
        }

        // Set Animator override
        animator.runtimeAnimatorController = jamesAnimatorOverrideControllers[(int)AnimatorOverrides.WITHOUT_WEAPON];

        Destroy(equippedWeapon.gameObject);
        equippedWeapon = null;
    }

    /// <summary>
    /// Equip C4
    /// </summary>
    /// <param name="weaponScriptable"></param>
    public void EquipC4(EquipmentScriptable equipmentScriptable)
    {
        if (!equipmentScriptable) return;

        C4.SetActive(true);
    }

    /// <summary>
    /// Unequip C4
    /// </summary>
    public void UnEquipC4()
    {
        if (!C4.activeSelf) return;
        
        C4.SetActive(false);
    }

}
