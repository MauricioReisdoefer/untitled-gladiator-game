using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFeedback : MonoBehaviour, IFeedback
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private float destroyAfter = 3f;

    public void RunFeedback(Vector2 position)
    {
        if (particlePrefab == null)
            return;

        GameObject instance = Instantiate(
            particlePrefab,
            position,
            Quaternion.identity
        );

        Destroy(instance, destroyAfter);
    }
}