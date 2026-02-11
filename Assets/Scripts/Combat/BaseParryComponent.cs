using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParryComponent : MonoBehaviour, IParryComponent, ISufferModifier
{
    [Header("Settings")]
    [SerializeField] private float damageReductionMultiplier = 0f;

    public bool IsParrying { get; private set; }
    public void SetParryState(bool state)
    {
        IsParrying = state;
    }

    public float GetSufferModifier()
    {
        return IsParrying ? damageReductionMultiplier : 1f;
    }

    public void OnSuccessfulParry(AttackData attackData)
    {
        Debug.Log($"Parry realizado com sucesso contra {attackData.Attacker.name}!");
    }
}