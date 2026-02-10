using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKeyboardAttackInput : MonoBehaviour, IAttackInput
{
    private IAttackComponent attackComponent;
    private IDamageApplier damageApplier;

    private DataComponent dataComponent;
    public void ExecuteAttack()
    {
        print("BaseKeyboardAttackInput: Ataque Iniciado");
        IData data = dataComponent.GetData();
        CombatData playerData = data as CombatData;

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;

        Collider2D[] hits = attackComponent.GetAttackHits(transform.position, direction, playerData.attackRange);
        foreach(Collider2D hit in hits)
        {
            AttackData attackData = new AttackData();
            attackData.Attacker = gameObject;
            attackData.Defender = hit.gameObject;
            attackData.knockback = playerData.knockback;
            attackData.damage = playerData.damage;
            attackData.parryTime = playerData.parryTime;
            attackData.timeStartTime = Time.time;
            damageApplier.ApplyDamage(attackData);
        }
    }
    private void Awake()
    {
        attackComponent = GetComponent<IAttackComponent>();
        damageApplier = GetComponent<IDamageApplier>();
        dataComponent = GetComponent<DataComponent>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            print("BaseKeyboardAttackInput: Ataque Iniciado");
            ExecuteAttack();
        }
    }
}
