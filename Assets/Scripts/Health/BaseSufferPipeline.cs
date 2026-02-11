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
        foreach (ISufferModifier modifier in modifiers)
        {
            float modifierValue = modifier.GetSufferModifier();

            if (modifier is IParryComponent parry && parry.IsParryActive)
            {
                parry.OnSuccessfulParry(attackData);
            }

            attackData.damage *= modifierValue;
        }
        Vector2 knockbackDirection = attackData.Defender.transform.position - attackData.Attacker.transform.position;
        rb.AddForce(knockbackDirection.normalized * attackData.knockback * attackData.damage);
        healthComponent.SufferDamage(attackData.damage);
    }
}
