using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
	public string fileName;
	public string filePath;
    private string persistenPath;
	public Info info = new Info();
	public Location location = new Location();
	public ShadowPlayer shadow = new ShadowPlayer();
	[Serializable]
	public struct Info
	{
		public List<string> names;
		//public int locationsCount;
		public string loadedLocation;
	}

	[Serializable, HideInInspector]
	public struct point
	{
		public float x, y, z;
	}
	[Serializable, HideInInspector]
	public struct Location
	{
		public string[] builds;
		public point[] pos;
	}
	[Serializable, HideInInspector]
	public struct ShadowPlayer
	{
		public MyDir.KV ListOfShadow;
	}
	public Data(string fp, string fn)
	{
		this.filePath = fp;
		this.fileName = fn;
        this.persistenPath = Application.persistentDataPath;
        
	}/*
    public void CreateInfo()
    {
        IFormatter iform = new BinaryFormatter();
        Directory.CreateDirectory(Environment.CurrentDirectory + filePath);
        FileStream fs = new FileStream(Environment.CurrentDirectory + 
            this.filePath + this.fileName, FileMode.Create);
        iform.Serialize(fs,new Info());
        info.locationsCount = 0;
        fs.Close();
    }/*
    public void CreateLocation()
    {
        IFormatter iform = new BinaryFormatter();
        Directory.CreateDirectory(Environment.CurrentDirectory + filePath);
        FileStream fs = new FileStream(Environment.CurrentDirectory +
            this.filePath + this.fileName, FileMode.Create);
        iform.Serialize(fs, new Location());
        info.locationsCount = 0;
        fs.Close();
    }*/

	public string[] FoundFileNames()
	{
		return Directory.GetFiles(this.persistenPath + this.filePath);
	}
	public bool IsExist()
	{
		return File.Exists(this.persistenPath +  this.filePath + this.fileName);
	}
	public void RewriteInfo()
	{
		IFormatter iform = new BinaryFormatter();
		FileStream fs = new FileStream(this.persistenPath + 
			this.filePath + this.fileName,FileMode.Create,FileAccess.Write);
		iform.Serialize(fs,this.info);
		fs.Close();
	}
	public void RewriteShadow()
	{
		IFormatter iform = new BinaryFormatter();
		FileStream fs = new FileStream(this.persistenPath +
			this.filePath + this.fileName, FileMode.Create, FileAccess.Write);
		iform.Serialize(fs, this.shadow);
		fs.Close();
	}
	public void RewriteLocation()
	{
		IFormatter iform = new BinaryFormatter();
		FileStream fs = new FileStream(this.persistenPath + 
			this.filePath + this.fileName, FileMode.Create, FileAccess.Write);
		iform.Serialize(fs, this.location);
		fs.Close();
	}
	public Info ReadInfo()
	{
		IFormatter iform = new BinaryFormatter();
		FileStream fs = new FileStream(this.persistenPath + 
			this.filePath + this.fileName, FileMode.Open, FileAccess.Read);
		Info inf = (Info)iform.Deserialize(fs);
		fs.Close();
		return inf;
	}
	public ShadowPlayer ReadShadow()
	{
		IFormatter iform = new BinaryFormatter();
		FileStream fs = new FileStream(this.persistenPath +
			this.filePath + this.fileName, FileMode.Open, FileAccess.Read);
		ShadowPlayer sh = (ShadowPlayer)iform.Deserialize(fs);
		fs.Close();
		return sh;
	}
	public Location ReadLocation()
	{
		IFormatter iform = new BinaryFormatter();
		FileStream fs = new FileStream(this.persistenPath + 

			this.filePath + this.fileName, FileMode.Open, FileAccess.Read);
		Location loc = (Location)iform.Deserialize(fs);
		fs.Close();
		return loc;
	}
	public void Remove()
	{
		File.Delete(this.persistenPath + 
			this.filePath+this.fileName);
	}
}