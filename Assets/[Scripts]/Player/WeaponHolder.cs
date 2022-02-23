using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    // Prefab of weapon
    [Header("WeaponToSpawn"), SerializeField]
    private GameObject WeaponToSpawn;
    
    // Ref to player controller
    public PlayerController _playerController;
    
    // Crosshair 
    private Sprite crosshairImage;

    // Weapon socket location
    [SerializeField]
    private GameObject WeaponScoketLocation;

    [SerializeField]
    private Transform GripIKScoketLocation;

    private WeaponComponent equippedWeapon;

    //private bool wasFiring = false;
    private bool firingPressed = false;


    // Animator
    private Animator animator;
    // Animations
    public readonly int isFiringHash = Animator.StringToHash("IsFiring");
    public readonly int isReloadingHash = Animator.StringToHash("IsReloading");

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnedWeapon = Instantiate(WeaponToSpawn, WeaponScoketLocation.transform.position,
            WeaponScoketLocation.transform.rotation, WeaponScoketLocation.transform);

        equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
        equippedWeapon.Initialize(this);
        GripIKScoketLocation = equippedWeapon.gripLocation;

        _playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();


        PlayerEvents.InvokeOnWeaponEquipped(equippedWeapon);

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
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, GripIKScoketLocation.transform.position);
    }

    public void OnFire(InputValue value)
    {

        // fix
        if (_playerController.isRunning)
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

    public void OnReload(InputValue value)
    {
        _playerController.isReloading = value.isPressed;
        StartReloading();
    }

    // Start Firing weapon
    private void StartFiring()
    {

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
        _playerController.isFiring = false;
        animator.SetBool(isFiringHash, false);
        equippedWeapon.StopFiringWeapon();
    }

    // Reload weapon
    public void StartReloading()
    {
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
}
