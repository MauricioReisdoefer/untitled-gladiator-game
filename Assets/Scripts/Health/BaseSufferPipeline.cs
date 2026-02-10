using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSufferPipeline : MonoBehaviour, ISufferPipeline
{
    private IHealthComponent healthComponent;
    private void Awake()
    {
        healthComponent = GetComponent<IHealthComponent>();
    }
    public void SufferDamage(AttackData attackData)
    {
        healthComponent.SufferDamage(attackData.damage);
    }
}
