using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Medikit
/// </summary>
[CreateAssetMenu(fileName = "Medikit", menuName = "Items/Medikit", order = 4)]
public class HPConsumableScriptable : ConsumableScriptable
{
    public override void UseItem(PlayerController playerController)
    {
        if (playerController.healthComponent.currentHealth >= playerController.healthComponent.maxHealth)
        {
            return;
        }
        else
        {
            playerController.healthComponent.TakeDamage(effect);
        }

        base.UseItem(playerController);
    }
}
