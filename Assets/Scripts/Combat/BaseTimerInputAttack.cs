using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTimerAttackInput : MonoBehaviour, IAttackInput
{
    [SerializeField] private float attackInterval = 3f;
    [SerializeField] private Vector2 attackDirection;

    private float nextAttackTime;

    private IAttackComponent attackComponent;
    private IDamageApplier damageApplier;
    private DataComponent dataComponent;

    public void ExecuteAttack()
    {
        IData data = dataComponent.GetData();
        CombatData playerData = data as CombatData;

        if (playerData == null)
            return;

        Vector2 direction = attackDirection;

        Collider2D[] hits = attackComponent.GetAttackHits(
            transform.position,
            direction,
            playerData.attackRange
        );

        foreach (Collider2D hit in hits)
        {
            AttackData attackData = new AttackData
            {
                Attacker = gameObject,
                Defender = hit.gameObject,
                knockback = playerData.knockback,
                damage = playerData.damage,
                parryTime = playerData.parryTime,
                timeStartTime = Time.time
            };

            damageApplier.ApplyDamage(attackData);
        }
    }

    private void Awake()
    {
        attackComponent = GetComponent<IAttackComponent>();
        damageApplier = GetComponent<IDamageApplier>();
        dataComponent = GetComponent<DataComponent>();
    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackInterval;
            ExecuteAttack();
        }
    }
}