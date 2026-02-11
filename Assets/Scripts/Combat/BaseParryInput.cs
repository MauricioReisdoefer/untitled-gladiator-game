using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParryInput : MonoBehaviour, IParryInput
{
    private IParryComponent parryComponent;
    private DataComponent dataComponent;

    private float nextParryTime;

    private void Awake()
    {
        parryComponent = GetComponent<IParryComponent>();
        dataComponent = GetComponent<DataComponent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time >= nextParryTime)
            {
                IData data = dataComponent.GetData();
                CombatData playerData = data as CombatData;

                if (playerData == null)
                    return;

                parryComponent?.TryActivateParry();

                nextParryTime = Time.time + playerData.parryCooldown;
            }
        }
    }
}