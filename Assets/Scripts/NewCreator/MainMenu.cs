using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public static int lavelLoadReqest;
    public Image soundBtn;
    public AudioSource backgroundMusic;
    public RectTransform content;
    public GameObject locbtnpref;
    private CameraMove camMove;
    private MapEditor mapeditor;
    private string[] possiblenames;
    //private List<string> accuratenames;
    public string root;
    public List<string> FoundFileNames()
    {
        DirectoryInfo dirInf = new DirectoryInfo(root);
        FileInfo[] fileInf = dirInf.GetFiles();
        //string [] paths = Directory.GetFiles(root);
        List<string> pp = new List<string>();

        for (int i = 0;i < fileInf.Length;i ++)
        {
            if (fileInf[i].Name.Substring(fileInf[i].Name.Length - 4, 4) == ".dat" && fileInf[i].Name[0]== 'L')
            {
                pp.Add(fileInf[i].Name);
            }
        }

        return pp;
    }
    private void Awake()
    {
        if(soundBtn)
            if (PlayerPrefs.GetInt("Parcour_sound_enable") == 1)
            {
                soundBtn.color = Color.gray;
            }
            else
            {
                soundBtn.color = Color.green;
            }
        root = Application.persistentDataPath;
        camMove = Camera.main.gameObject.GetComponent<CameraMove>();
        GameObject go;
        int n = PlayerPrefs.GetInt("LocationsCount");
        if (Application.loadedLevel == 0)
        {
            possiblenames = FoundFileNames().ToArray();

            foreach (string str in possiblenames)
            {
                    print(str);
                    go = Instantiate<GameObject>(locbtnpref);
                    go.name = "Location" + str.Substring(8,str.Length-4-8) + ".dat";
                    go.transform.SetParent(content.transform);
                    go.transform.localPosition = Vector3.zero;
                    go.transform.localScale = new Vector2(1.5f, 0.5f);
            }
        }
        else
        {
            mapeditor = GameObject.Find("Scroll View").GetComponent<MapEditor>();
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && Application.loadedLevel != 0)
        {
            camMove.CanMove();
        }
    }

    public void LoadSceene(int num)
    {
        lavelLoadReqest = num;
        Application.LoadLevel(3);
    }
    public void InverceViseble(GameObject panel)
    {
        panel.SetActive(!panel.active);
    }
    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void CloseAplication()
    {
        Application.Quit();
    }
    public void AddLocation()
    {
        PlayerPrefs.SetString("CreatorMode", "IsNew");
        Application.LoadLevel(1);
    }
    public void SetPause(bool value)
    {
        if(value)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void SetSoundEnable(Image thisBtn)
    {
        backgroundMusic = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Parcour_sound_enable") == 1)
        {
            PlayerPrefs.SetInt("Parcour_sound_enable", 0);
            backgroundMusic.enabled = true;
            thisBtn.color = Color.green;
        }
        else
        {
            PlayerPrefs.SetInt("Parcour_sound_enable", 1);
            backgroundMusic.enabled = false;
            thisBtn.color = Color.gray;
        }
            
    }
}
