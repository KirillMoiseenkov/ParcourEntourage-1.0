using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class LocationData : AbstractData
{
    private string persistenpath;
    public MapEditor mapeditor;
    public List<GameObjectPrefab> sceeneprefs;

    public LocationData(string filename, string filepath)
    {
        this.filename = filename;
        this.filepath = filepath;
        this.persistenpath = Application.persistentDataPath;
        if(GameObject.Find("Canvas") != null)
            mapeditor = GameObject.Find("Canvas").GetComponent<MapEditor>();
    }

    public override List<GameObjectPrefab> LoadData()
    {
        IFormatter iform = new BinaryFormatter();
        FileStream fs = new FileStream(this.persistenpath +
            this.filepath + this.filename, FileMode.Open, FileAccess.Read);
        List<GameObjectPrefab> gos = (List<GameObjectPrefab>)iform.Deserialize(fs);
        fs.Close();
        return gos;
    }
    public override void SaveData()
    {
        GameObjectConverter Converter = new GameObjectBuildConverter();
        sceeneprefs = Converter.Serelizator(mapeditor.buildslist);
        IFormatter iform = new BinaryFormatter();
        print(this.persistenpath);
        FileStream fs = new FileStream(this.persistenpath +
            this.filepath + this.filename, FileMode.Create, FileAccess.Write);
        iform.Serialize(fs, sceeneprefs);
        fs.Close();
    }
    public override void Remove()
    {
        File.Delete(this.persistenpath +
            this.filepath + this.filename);
    }
}
