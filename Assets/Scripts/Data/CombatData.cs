using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatData", menuName = "Data/Combat")]
public class CombatData : ScriptableObject, IData
{
    [Header("Movement")]
    public float speed;
    public float stopSpeed;
    public float dashSpeed;

    [Header("Combat")]
    public float attackRange;
    public float damage;
    public float knockback;
    public float parryCooldown;
}
