using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Component : WeaponComponent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void FireWeapon()
    {
        Vector3 hitLocation;

        if (weaponStats.bulletsInClip > 0 && !isReloading && !weaponHolder._playerController.isRunning)
        {
            base.FireWeapon();

            

            Ray screenRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));

            // fix. put everything in the actual if condition
            if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponHitLayers))
            {
                hitLocation = hit.point;

                Vector3 hitDirection = hit.point - mainCamera.transform.position;

                Debug.DrawRay(mainCamera.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1f);
            }

            //Debug.Log("Bullet Count = " + weaponStats.bulletsInClip);

        }
        else if (weaponStats.bulletsInClip <= 0)
        {
            weaponHolder.StartReloading();
        }
    }
}
