using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSufferPipeline : MonoBehaviour, ISufferPipeline
{
    private IHealthComponent healthComponent;
    private ISufferModifier[] modifiers;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        modifiers = GetComponents<ISufferModifier>();
        healthComponent = GetComponent<IHealthComponent>();
    }
    public void SufferDamage(AttackData attackData)
    {
        print("BaseSufferPipeline: Sofrendo Dano");
        foreach (ISufferModifier modifier in modifiers)
        {
            attackData.damage *= modifier.GetSufferModifier();
        }
        Vector2 knockbackDirection = attackData.Defender.transform.position - attackData.Attacker.transform.position;
        rb.AddForce(knockbackDirection.normalized * attackData.knockback * attackData.damage);
        healthComponent.SufferDamage(attackData.damage);
    }
}
