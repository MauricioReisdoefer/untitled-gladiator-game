using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamageApplier : MonoBehaviour, IDamageApplier
{
    private IDamageModifier[] modifiers;
    private void Awake()
    {
        modifiers = GetComponents<IDamageModifier>();
    }
    public void ApplyDamage(AttackData attackData)
    {
        foreach(IDamageModifier modifier in modifiers)
        {
            attackData.damage *= modifier.GetDamageModifier();
        }
        ISufferPipeline pipeline = attackData.Defender.GetComponent<ISufferPipeline>();
        if (pipeline == null) 
        {
            return;
        }
        pipeline.SufferDamage(attackData);
    }
}
