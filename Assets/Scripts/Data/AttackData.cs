using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttackData
{
    [Header("Damage")]
    public float damage;

    [Header("Physics")]
    public float knockback;

    [Header("Timing")]
    [Tooltip("Janela de tempo (em segundos) em que o ataque pode ser aparado")]
    public float parryTime;
    public float timeStartTime;

    [Header("World")]
    public GameObject Attacker;
    public GameObject Defender;
}
