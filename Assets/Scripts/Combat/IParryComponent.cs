using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParryComponent
{
    bool IsParryActive { get; }

    void TryActivateParry();         
    void OnSuccessfulParry(AttackData attackData);
}
