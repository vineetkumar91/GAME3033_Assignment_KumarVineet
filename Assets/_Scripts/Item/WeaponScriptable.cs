using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 2)]
public class WeaponScriptable : EquippableScriptable
{
    public WeaponStats weaponStats;

    public override void UseItem(PlayerController playerController)
    {
       

        if (Equipped)
        {
            // unequip from inventory and controller
            playerController.weaponHolder.UnquipWeapon();
        }
        else
        {
            // invoke on weapon equipped from player events here from inventory and equip weapon from weapon holder on player controller
            playerController.weaponHolder.UnquipWeapon();
            playerController.weaponHolder.EquipWeapon(this);
        }

        base.UseItem(playerController);
    }
}
