using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEditor : MonoBehaviour
{
    private Vector3 BufPosition;
    public GameObject sellection;
    public string mode;
    public string loc;
    public GameObject[] prefabs;
    public GameObject cam;
    private Vector3 spawn_pos;
    private DirectorySearch ds;
    public GameObject character_pref;
    public Color sellected_color;
    public bool CanMoveObjects = true;

    public List<GameObject> buildslist;
    public void Awake()
    {
            
        ds = new DirectorySearch();
        cam = Camera.main.gameObject;
        mode = PlayerPrefs.GetString("CreatorMode");
        switch(mode)
        {
            case "IsEdit":
                loc = PlayerPrefs.GetString("LocationLoad");
                GameObject buf;
                GameObjectConverter Converter = new GameObjectBuildConverter();
                LocationData loc_dat = new LocationData(@"/" + loc, "");
                this.buildslist = Converter.Deserelizator(loc_dat.LoadData(), prefabs, null);
                break;
            case "IsNew":
                AddToList(character_pref);
                break;
            default:
                print("Unknow mode!");
                break;
        }
        if(sellection)sellected_color = sellection.GetComponent<Renderer>().material.color;
    }

    public void ChangeCanMoveObjects(Text txt)
    {
        CanMoveObjects = !CanMoveObjects;
        if (CanMoveObjects)
            txt.text = "To View";
        else
            txt.text = "To Edit";
    }

    public void SaveAllAndBackToMenu()
    {
        int c = PlayerPrefs.GetInt("LocationsCount");
        int cc = ds.GetCount();
        if (mode == "IsNew")
        {
            if (cc == 0) c = 1;
            else c++;
        }
        PlayerPrefs.SetInt("LocationsCount",c);
        LocationData ld = new LocationData(@"/Location" + c + ".dat", "");
        ld.SaveData();
        /*
        string n = PlayerPrefs.GetString("LocationLoad");
        LocationData location = new LocationData(@"\" + n + ".dat","");
        location.SaveData();
        */
        Application.LoadLevel(0);
    }
    public void BackToMenu()
    {
        Application.LoadLevel(0);
    }


    public void AddToList(GameObject pref)
    {
        spawn_pos = cam.transform.position;
        spawn_pos.z = 0;
        GameObject newbuild = Instantiate<GameObject>(pref,spawn_pos,pref.transform.rotation);
        newbuild.name = pref.name;
        buildslist.Add(newbuild);
    }
    public void RemoveFromList()
    {
        if (sellection.GetComponent<ActionsWithPref>().isDeleteble)
        {
            buildslist.Remove(sellection);
            GameObject.Destroy(sellection);
        }
    }
}
