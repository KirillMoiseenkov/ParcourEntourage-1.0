using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationButton : MonoBehaviour
{
    public RectTransform label;
    private string num;
    private Text txt;

    private DirectorySearch ds;

    private void Start()
    {
        ds = Camera.main.gameObject.GetComponent<DirectorySearch>();
        txt = label.GetComponent<Text>();
        txt.text = this.name.Substring(0, this.name.Length - 4);
        num = txt.text.Substring(8, txt.text.Length - 8);
    }

    public void EditThisMap()
    {
        string loacation_name = this.name;
        PlayerPrefs.SetString("CreatorMode", "IsEdit");
        PlayerPrefs.SetString("LocationLoad", loacation_name);
        MainMenu.lavelLoadReqest = 1;
        Application.LoadLevel(3);
    }

    public void GoToCreatedLocation()
    {
        PlayerPrefs.SetString("LocationLoad", this.name);
        MainMenu.lavelLoadReqest = 2;
        Application.LoadLevel(3);
    }

    public void RemoveLocation()
    {
        int c = PlayerPrefs.GetInt("LocationsCount");
        int cc = ds.GetCount();
        LocationData ld = new LocationData(@"/" + this.name, "");
        if (this.num == (c + ""))
        {
            if (cc > 0) c--;
            else { c = 0; }
        }
        PlayerPrefs.SetInt("LocationsCount", c);
        ld.Remove();
        GameObject.Destroy(this.gameObject);
    }
}
