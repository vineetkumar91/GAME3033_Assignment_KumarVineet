using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    
    public float currentHealth;
    public float maxHealth;
    public float HPbeforeDamage;
    public bool isUpdatingHPBar = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Virtual Destroy function
    /// </summary>
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Take Damage .. update it to UpdateHP
    /// </summary>
    /// <param name="damage"></param>
    public virtual void TakeDamage(float damage)
    {
        UpdateHP(damage);
    }

    /// <summary>
    /// Updates HP
    /// </summary>
    /// <param name="damage"></param>
    public void UpdateHP(float damage)
    {
        HPbeforeDamage = currentHealth;

        currentHealth += damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        isUpdatingHPBar = true;

        if (currentHealth <= 0)
        {
            Destroy();
        }
    }
}
