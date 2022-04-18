using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthComponent : HealthComponent
{
    protected override void Start()
    {
        base.Start();
        PlayerEvents.Invoke_OnHealthInitialized(this);
    }

    public override void Destroy()
    {
        GetComponent<MovementComponent>().PlayerIsDead();

        if (GetComponent<PlayerController>())
        {
            SFXManager.GetInstance().audioSource.clip = PlayerSounds.GetInstance().audioClip[(int)PlayerSFX.Dead];
            SFXManager.GetInstance().audioSource.volume = 0.5f;
            SFXManager.GetInstance().audioSource.Play();
        }


        Debug.Log("Player is dead");
        Data.hasWon = false;
        //SceneManager.LoadScene(2);
    }
}
