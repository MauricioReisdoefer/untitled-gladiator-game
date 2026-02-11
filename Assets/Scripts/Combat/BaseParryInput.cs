using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParryInput : MonoBehaviour, IParryInput
{
    private IParryComponent parryComponent;

    private void Awake()
    {
        parryComponent = GetComponent<IParryComponent>();
    }

    private void Update()
    {
        bool isPressed = IsParryPressed();
        parryComponent.SetParryState(isPressed);
    }

    public bool IsParryPressed()
    {
        return Input.GetMouseButton(1);
    }
}