using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackComponent
{
    public Collider2D[] GetAttackHits(Vector2 origin, Vector2 direction);
}
