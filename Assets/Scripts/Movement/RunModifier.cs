using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunModifier : MonoBehaviour, ISpeedModifier
{
    [SerializeField] private float runIntensity;
    [SerializeField] private KeyCode key;
    public float GetSpeedModifier()
    {
        if (Input.GetKey(key))
        {
            return runIntensity;
        }
        return 1;
    }
}
