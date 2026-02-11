using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParryComponent
{
    bool IsParrying { get; }
    void OnSuccessfulParry(AttackData attackData);
    void SetParryState(bool state);
}
