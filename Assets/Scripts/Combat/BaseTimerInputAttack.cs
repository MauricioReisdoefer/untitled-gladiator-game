using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTimerAttackInput : MonoBehaviour, IAttackInput
{
    [SerializeField] private float attackInterval = 3f;
    [SerializeField] private Vector2 attackDirection;
    [SerializeField] private Color blinkColor;

    private float nextAttackTime;

    private IAttackComponent attackComponent;
    private IDamageApplier damageApplier;
    private DataComponent dataComponent;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

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
                parryTime = playerData.parryCooldown,
                timeStartTime = Time.time
            };

            damageApplier.ApplyDamage(attackData);
        }

        if (spriteRenderer != null)
            spriteRenderer.color = originalColor;
    }

    private void Awake()
    {
        attackComponent = GetComponent<IAttackComponent>();
        damageApplier = GetComponent<IDamageApplier>();
        dataComponent = GetComponent<DataComponent>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;

        nextAttackTime = Time.time + attackInterval;
    }

    private void Update()
    {
        if (spriteRenderer != null)
        {
            float timeRemaining = nextAttackTime - Time.time;
            float t = 1f - Mathf.Clamp01(timeRemaining / attackInterval);
            spriteRenderer.color = Color.Lerp(originalColor, blinkColor, t);
        }

        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackInterval;
            ExecuteAttack();
        }
    }
}
