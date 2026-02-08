using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float speed;
    public float stopSpeed;
    public float dashSpeed;
}
