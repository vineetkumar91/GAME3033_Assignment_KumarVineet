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
        Debug.Log("Player is dead");
        Data.hasWon = false;
        SceneManager.LoadScene(2);
    }
}
