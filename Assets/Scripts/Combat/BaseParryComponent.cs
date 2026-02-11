using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParryComponent : MonoBehaviour, IParryComponent, ISufferModifier
{
    [Header("Settings")]
    [SerializeField] private float parryWindowDuration = 0.25f;

    private float parryTimer;
    private bool isParryActive;

    public bool IsParryActive => isParryActive;

    private void Update()
    {
        UpdateParryWindow();
    }

    public void TryActivateParry()
    {
        if (isParryActive)
            return;

        isParryActive = true;
        parryTimer = parryWindowDuration;
    }

    private void UpdateParryWindow()
    {
        if (!isParryActive)
            return;

        parryTimer -= Time.deltaTime;

        if (parryTimer <= 0f)
        {
            isParryActive = false;
        }
    }

    public float GetSufferModifier()
    {
        return isParryActive ? 0f : 1f;
    }

    public void OnSuccessfulParry(AttackData attackData)
    {
        Debug.Log($"Parry perfeito contra {attackData.Attacker.name}!");
        isParryActive = false;
    }
}