using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractData : MonoBehaviour
{
    protected string filename = "";
    protected string filepath = "";

    public virtual void SaveData() { }
    public virtual List<GameObjectPrefab> LoadData() { return null; }
    public virtual void Remove() { }
}
