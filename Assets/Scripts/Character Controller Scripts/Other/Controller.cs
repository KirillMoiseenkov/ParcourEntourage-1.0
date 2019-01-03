using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
//public class Controller : CharacterMain
//public class Controller : Character						
public class Controller: MonoBehaviour
{

	 int i = 1;
    [SerializeField]
    private string last_count = "";
    [SerializeField]
    private string action = "";
    [SerializeField]
    private GameObject[] points;
    private GameObject Img;
	public Character chara;
    //public GameObject characterGO;
	//for Shadow
	public float time = 1;
	public ShadowOfPlayer SOP;
	private Data data_shadow;
	public MyDir ListOfShadow = new MyDir();
    public Data.point point = new Data.point();
    public bool canWallRun = false;
    //////////////
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /////////////
    IEnumerator Timer()
	{
		while (true) {

			yield return new WaitForSeconds (0.2f);
			time+=1f;
		}

	}


	public void colorator(GameObject img)
    {
        if (Input.GetMouseButton(0))
        {
            img.GetComponent<Image>().color = new Color(0, 1, 0, 0.25f); Img = img;
        }
    }

    public void btn_clicked()
    {
        if (Input.GetMouseButton(0))
        {
            if (action.Length == 0)
            {
                action += "s";
                last_count = Img.name;
            }
            else
            {
                if (Img.name != ("" + last_count))
                { action += ("" + (Convert.ToInt32(Img.name) - Convert.ToInt32(last_count))); last_count = Img.name; }
            }
        }
    }

    public void BackToMenu()
    { Application.LoadLevel(0); }
    public void Restart()
    { Application.LoadLevel(Application.loadedLevel); }

    public void setCanWallRun()
    {
        canWallRun = true;
    }

    private void Awake()
	{
		data_shadow = new Data(@"/","shadow.dat");
        if (!data_shadow.IsExist())
		{
            data_shadow.shadow.ListOfShadow = new MyDir().kv;
            data_shadow.RewriteShadow();
		}
        data_shadow.shadow = data_shadow.ReadShadow();
	
	}
	private void Start()
	{
		StartCoroutine (Timer ());

	}

    
	private void LateUpdate()
    {
        if(canWallRun)
        {
            point.x = chara.transform.position.x;
            point.y = chara.transform.position.y;
            ListOfShadow.Push_Element_MyDir(point, "WallRun");

            canWallRun = false;
        }
		if(Input.GetKey(KeyCode.S))
		{
			data_shadow.shadow.ListOfShadow = this.ListOfShadow.kv;
			data_shadow.RewriteShadow();
		}
		if (Input.GetKey (KeyCode.A)) 
		{


		}
			
        if (Input.GetMouseButtonUp(0))
        {
			point.x = chara.transform.position.x;
			point.y = chara.transform.position.y;
			// print(point.x + " " + point.y);
            ListOfShadow.Push_Element_MyDir (point,action);
			//print(ListOfShadow.Return_key_MyDir().x);
			chara.addElementToQueue (action);
            
			action = "";


			for (int a = 0; a < points.Length; a++)
            {
                this.points[a].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.03f);
			}


				
		}
    }
}
