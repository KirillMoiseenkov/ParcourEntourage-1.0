using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceene : MonoBehaviour
{
    public GameObject shadow;
    public List<GameObject> builds;
    public string filename;
    public GameObject[] prefabs;

    private void Start()
    {
        filename = PlayerPrefs.GetString("LocationLoad");
        GameObject buf;

        GameObjectConverter Converter = new GameObjectBuildConverter();
        LocationData loc_dat = new LocationData(@"/" + filename, "");
        Converter.Deserelizator(loc_dat.LoadData(), prefabs, shadow);
    }
}
