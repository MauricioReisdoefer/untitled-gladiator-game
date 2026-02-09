using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthComponent
{
    public void Heal(float health);
    public void Die();
    public void SufferDamage(float health);
    public float GetCurrentHealth();
    public float GetMaxHealth();
}
