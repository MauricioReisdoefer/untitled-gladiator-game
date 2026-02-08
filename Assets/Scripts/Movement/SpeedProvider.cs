using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedProvider : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    private ISpeedModifier[] speedModifiers;

    private void Awake()
    {
        speedModifiers = GetComponents<ISpeedModifier>();
    }

    /// <summary>
    /// It uses ISpeedModifiers inside it's GameObject to process the current speed based on the baseSpeed field
    /// </summary>
    /// <returns>A float of the current speed</returns>
    public float GetCurrentSpeed()
    {
        float speed = baseSpeed;
        foreach(ISpeedModifier speedModifier in speedModifiers)
        {
            speed *= speedModifier.GetSpeedModifier();
        }
        return speed;
    }
}
