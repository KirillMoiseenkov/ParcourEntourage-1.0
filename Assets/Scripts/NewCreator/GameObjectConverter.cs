using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectConverter : MonoBehaviour
{
    protected Vector3 pos;
    protected GameObject go;
    public virtual List<GameObject> Deserelizator(List<GameObjectPrefab> gops, GameObject[] prefs, GameObject shadow)
    { return null; }
    public virtual List<GameObjectPrefab> Serelizator(List<GameObject> gos)
    { return null; }
}

public class GameObjectBuildConverter : GameObjectConverter
{
    public override List<GameObjectPrefab> Serelizator(List<GameObject> gos)
    {
        List<GameObjectPrefab> gops = new List<GameObjectPrefab>();
        for (int i = 0; i < gos.Count; i++)
        {
            gops.Add(new Build(gos[i]));
        }
        return gops;
    }
    public override List<GameObject> Deserelizator(List<GameObjectPrefab> gops, GameObject [] prefs, GameObject shadow)
    {
        List<GameObject> gos = new List<GameObject>();
        /*
        Vector3 pos = new Vector3();
        GameObject[] buf = new GameObject[gops.Count];
        for(int i = 0;i < gops.Count;i ++)
        {
            buf[i] = new GameObject();
            buf[i].name = gops[i].GetObjectName();
            pos.x = gops[i].GetPos().posx;
            pos.y = gops[i].GetPos().posy;
            pos.z = 0;
            buf[i].transform.position = pos;
            gos.Add(buf[i]);
        }
        */
        for (int j = 0; j < prefs.Length; j++)
        {
            for (int i = 0; i < gops.Count; i++)
            {
                if(prefs[j].name == gops[i].GetObjectName())
                {
                    go = Instantiate<GameObject>(prefs[j]);
                    pos.x = gops[i].GetPos().posx;
                    pos.y = gops[i].GetPos().posy;
                    pos.z = 0;
                    go.transform.position = pos;
                    go.name = prefs[j].name;
                    gos.Add(go);
                    if (go.tag == "character")
                    {
                        GameObject sh = Instantiate<GameObject>(shadow,go.transform.position,go.transform.rotation);
                        sh.name = shadow.name;
                        go.GetComponent<Character>().Shad = GameObject.FindGameObjectWithTag("ShadowRot");
                    }
                }

            }
        }
        return gos;
    }
}