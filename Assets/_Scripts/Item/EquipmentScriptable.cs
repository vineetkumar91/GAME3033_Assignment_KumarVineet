using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Items/Equipment", order = 3)]
public class EquipmentScriptable : EquippableScriptable
{
    public override void UseItem(PlayerController playerController)
    {
        if (Equipped)
        {
            // unequip from inventory and controller
            playerController.weaponHolder.UnEquipC4();
            GameManager.GetInstance().isC4Equipped = false;
            GameManager.GetInstance().isReadyToPlant = false;
        }
        else
        {
            // invoke on weapon equipped from player events here from inventory and equip weapon from weapon holder on player controller
            playerController.weaponHolder.UnEquipWeapon();
            playerController.weaponHolder.EquipC4(this);
            GameManager.GetInstance().isC4Equipped = true;
            //GameManager.GetInstance().C4Equipment = this;
        }

        base.UseItem(playerController);
    }


    /// <summary>
    /// Delete C4
    /// </summary>
    public void DeleteC4Item(PlayerController playerController)
    {
        //DeleteItem(playerController);
    }
}
