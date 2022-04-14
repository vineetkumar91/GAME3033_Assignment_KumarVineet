using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Component : WeaponComponent
{
    Vector3 hitLocation;
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

            Ray screenRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));
            
            // fix. put everything in the actual if condition
            if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponHitLayers))
            {
                hitLocation = hit.point;

                DealDamage(hit);

                Vector3 hitDirection = hit.point - mainCamera.transform.position;

                //Debug.DrawRay(mainCamera.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1f);
            }

            //Debug.Log("Bullet Count = " + weaponStats.bulletsInClip);

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitLocation, 0.2f);
    }
}
