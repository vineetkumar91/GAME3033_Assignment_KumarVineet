using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncherScript : WeaponComponent
{
    Vector3 hitLocation;

    [Header("Nade and its Launch Point")]
    public Transform muzzlePointSocket;
    public GameObject Nade;

    [Header("Physics")]
    public float ProjectileForce;
    public float ProjectileUpwardForce;
    protected override void FireWeapon()
    {
        if (weaponStats.bulletsInClip > 0 && !isReloading && !weaponHolder._playerController.isRunning)
        {
            base.FireWeapon();

            // Particle effect

            if (firingEffect)
            {
                firingEffect.Play();
            }

            //---------

            GameObject projectile = Instantiate(Nade, muzzlePointSocket.position, mainCamera.transform.rotation);

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            Vector3 forceDirection = mainCamera.transform.forward;

            Ray screenRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));

            if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance))
            {
                hitLocation = hit.point;

                Vector3 hitDirection = (hit.point - mainCamera.transform.position).normalized;

                Vector3 forceToAdd = hitDirection * ProjectileForce + mainCamera.transform.up * ProjectileUpwardForce;

                projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

            }

        }
        else if (weaponStats.bulletsInClip <= 0)
        {
            weaponHolder.StartReloading();
        }
    }

    void DealDamage(RaycastHit hitInfo)
    {
        IDamageable damageable = hitInfo.collider.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(weaponStats.damage);
    }
}
