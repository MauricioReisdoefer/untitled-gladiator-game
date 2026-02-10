using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataComponent : MonoBehaviour, IDataComponent
{
    public PlayerData playerData;
    public IData GetData()
    {
        return playerData;
    }
}
