using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class GameObjectPrefab
{
    [System.Serializable]
    public struct Point
    {
        public float posx;
        public float posy;
    }

    protected Point pos;

    protected string object_name;

    public Point GetPos()
    {
        return this.pos;
    }
    public string GetObjectName()
    { return this.object_name; }
}
[System.Serializable]
public class Build : GameObjectPrefab
{
    public Build()
    { }
    public Build(GameObject go)
    {
        this.pos.posx = go.transform.position.x;
        this.pos.posy = go.transform.position.y;
        this.object_name = go.gameObject.name;
    }
}
