using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAttackComponent : MonoBehaviour, IAttackComponent
{
    public LayerMask layerMask;
    public Collider2D[] GetAttackHits(Vector2 origin, Vector2 direction, float distance)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction, distance, layerMask);

        List<Collider2D> colliders = new List<Collider2D>();

        foreach (var hit in hits)
            colliders.Add(hit.collider);

        return colliders.ToArray();
    }
}
