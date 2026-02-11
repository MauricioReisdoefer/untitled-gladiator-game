using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthComponent : MonoBehaviour, IHealthComponent
{
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void Heal(float health)
    {
        currentHealth += health;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public virtual void SufferDamage(float health)
    {
        print("BaseHealthComponent: Sofri " + health + " de dano");
        currentHealth -= health;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual float GetCurrentHealth()
    {
        return currentHealth;
    }

    public virtual float GetMaxHealth()
    {
        return maxHealth;
    }
}
