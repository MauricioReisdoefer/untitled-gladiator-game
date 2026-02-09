using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementComponent : MonoBehaviour
{
    private IDirectionProvider directionProvider;
    private SpeedProvider speedProvider;
    private Rigidbody2D rb;
    void Start()
    {
        directionProvider = GetComponent<IDirectionProvider>();
        speedProvider = GetComponent<SpeedProvider>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(directionProvider.GetCurrentDirection() * speedProvider.GetCurrentSpeed() * Time.deltaTime);
    }
}
