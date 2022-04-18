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
            PlayerSounds.GetInstance().audioSource.volume = 0.5f;
            PlayerSounds.GetInstance().audioSource.clip =
                PlayerSounds.GetInstance().audioClip[(int)PlayerSFX.Medikit];
            PlayerSounds.GetInstance().audioSource.Play();
        }

        base.UseItem(playerController);
    }
}
