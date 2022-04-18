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
using UnityEngine.UI;


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
    private GameObject WeaponSocketLocation;

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

    [Header("Crosshair")] 
    public Image Crosshair;
    public Sprite AK47CrossHair;
    public Sprite NadeCrossHair;
    public Sprite EmptyCrossHair;
    


    // Start is called before the first frame update
    void Start()
    {
       //spawnedWeapon = Instantiate(WeaponToSpawn, WeaponSocketLocation.transform.position,
       //    WeaponSocketLocation.transform.rotation, WeaponSocketLocation.transform);

        animator = GetComponent<Animator>();
        weaponAmmoDictionary = new Dictionary<WeaponType, WeaponStats>();
        _playerController = GetComponent<PlayerController>();

        animator.runtimeAnimatorController = jamesAnimatorOverrideControllers[(int)AnimatorOverrides.WITHOUT_WEAPON];

        Crosshair.sprite = EmptyCrossHair;

        // 2nd Feb
        //equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
        //equippedWeapon.Initialize(this);

        // Events...
        //PlayerEvents.InvokeOnWeaponEquipped(equippedWeapon);
        /// Events


        //GripIKScoketLocation = equippedWeapon.gripLocation;



        // Adds Start Weapon        
        //_playerController.inventory.AddItem(startWeapon, 1);

        //weaponAmmoDictionary.Add(startWeapon.weaponStats.weaponType, startWeapon.weaponStats);
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
        if (GameManager.GetInstance().isPlayerDead)
        {
            StopFiring();
            return;
        }

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
        if (!GameManager.GetInstance().isPlayerDead)
        {
            _playerController.isReloading = value.isPressed;
            StartReloading();
        }
        
    }

    // Start Firing weapon
    private void StartFiring()
    {
        if (!equippedWeapon) return;

        if (_playerController.isInventoryOn)
        {
            return;
        }

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
        if (GameManager.GetInstance().isPlayerDead)
        {
            return;
        }

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

        if (equippedWeapon.weaponStats.weaponName == "AK-47")
        {
            PlayerSounds.GetInstance().audioSource.volume = 0.5f;
            PlayerSounds.GetInstance().audioSource.clip =
                PlayerSounds.GetInstance().audioClip[(int)PlayerSFX.Reload];
            PlayerSounds.GetInstance().audioSource.Play();
        }
        else
        {
            PlayerSounds.GetInstance().audioSource.volume = 0.05f;
            PlayerSounds.GetInstance().audioSource.clip =
                PlayerSounds.GetInstance().audioClip[(int)PlayerSFX.Reload];
            PlayerSounds.GetInstance().audioSource.Play();
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

        spawnedWeapon = Instantiate(weaponScriptable.itemPrefab, WeaponSocketLocation.transform.position, WeaponSocketLocation.transform.rotation, WeaponSocketLocation.transform);

        if (!spawnedWeapon) return;

        equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();

        if (!equippedWeapon) return;

        equippedWeapon.Initialize(this, weaponScriptable);

        if (weaponAmmoDictionary.ContainsKey(equippedWeapon.weaponStats.weaponType))
        {
            equippedWeapon.weaponStats = weaponAmmoDictionary[equippedWeapon.weaponStats.weaponType];
        }

        // Switch crosshair with that
        switch (equippedWeapon.weaponStats.weaponType)
        {
            case WeaponType.MachineGun:
                Crosshair.sprite = AK47CrossHair;
                break;

            case WeaponType.Launcher:
                Crosshair.sprite = NadeCrossHair;
                break;

            default:
                Crosshair.sprite = EmptyCrossHair;
                break;
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


        // Crosshair remove
        Crosshair.sprite = EmptyCrossHair;

        PlayerEvents.InvokeUnequipWeapon();

    }

    /// <summary>
    /// Equip C4
    /// </summary>
    /// <param name="weaponScriptable"></param>
    public void EquipC4(EquipmentScriptable equipmentScriptable)
    {
        if (GameManager.GetInstance().isPlayerDead)
        {
            return;
        }

        if (!equipmentScriptable) return;

        C4.SetActive(true);

        PlayerEvents.InvokeOnC4Equipped();
    }

    /// <summary>
    /// Unequip C4
    /// </summary>
    public void UnEquipC4()
    {
        if (GameManager.GetInstance().isPlayerDead)
        {
            return;
        }

        if (!C4.activeSelf) return;
        
        C4.SetActive(false);
    }


    /// <summary>
    /// Player dead function for weapons
    /// </summary>
    public void PlayerIsDead()
    {
        StopFiring();
    }
}
