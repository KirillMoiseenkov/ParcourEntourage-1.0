using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorySearch : MonoBehaviour
{
    private MainMenu mm;
    public List<string> filenames;

    public DirectorySearch()
    {
        filenames = new List<string>();
        mm = new MainMenu();
    }

    public int GetCount()
    {
        mm.root = Application.persistentDataPath;
        filenames.AddRange(mm.FoundFileNames());
        return filenames.Count;
    }
}
