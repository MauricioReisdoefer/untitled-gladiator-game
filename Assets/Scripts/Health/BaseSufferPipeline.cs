using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSufferPipeline : MonoBehaviour, ISufferPipeline
{
    private IHealthComponent healthComponent;
    private ISufferModifier[] modifiers;
    private void Awake()
    {
        modifiers = GetComponents<ISufferModifier>();
        healthComponent = GetComponent<IHealthComponent>();
    }
    public void SufferDamage(AttackData attackData)
    {
        foreach(ISufferModifier modifier in modifiers)
        {
            attackData.damage *= modifier.GetSufferModifier();
        }
        healthComponent.SufferDamage(attackData.damage);
    }
}
