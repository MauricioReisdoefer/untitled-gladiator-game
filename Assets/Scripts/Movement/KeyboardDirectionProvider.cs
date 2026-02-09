using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardDirectionProvider : MonoBehaviour, IDirectionProvider
{
    public Vector2 GetCurrentDirection()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y);

        return direction.normalized;
    }
}
