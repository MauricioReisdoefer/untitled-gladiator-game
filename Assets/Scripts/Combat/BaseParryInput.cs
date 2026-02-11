using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParryInput : MonoBehaviour
{
    private IParryComponent parryComponent;

    private void Awake()
    {
        parryComponent = GetComponent<IParryComponent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            parryComponent?.TryActivateParry();
        }
    }
}