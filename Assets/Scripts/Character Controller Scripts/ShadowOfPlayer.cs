using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShadowOfPlayer : AbstractClassOfPlayer {

													
			
	public string ground_checker_SH = "GC_Shadow";
	public string character_SH = "Shadow";
	public string player_SH = "ShadowPlayer";
	public string rot_SH = "ShadowRot";
	public float time = 1;
	public bool begin;
	public string action = "";
	public Controller Cont;
	public bool Camera;
	public bool Moves;
	//public Dictionary<float,string> ListOfShadow = new Dictionary<float,string>();
	public string test = "";
    private Data data_shadow;
    public Character chara;
    public Data.point point = new Data.point();
    public float E = 0.1f;
		    																																							





	IEnumerator Timer()
	{
		while (true) {

            yield return new WaitForSeconds(0.2f);

			time+=1f;
		}
	 
	}



	private void Awake()
	{
		
		base.Init (player_SH, false, true,ground_checker_SH,character_SH,player_SH,rot_SH);


		data_shadow = new Data(@"/", "shadow.dat");
        if (data_shadow.IsExist())
        {
            data_shadow.shadow = data_shadow.ReadShadow();
            ListOfShadow.kv = data_shadow.shadow.ListOfShadow;
        }


    }

	private void Start()
	{
		StartCoroutine (Timer ());
	
	
	}



	public void Update()
	{
		
		CheckOnPosition ();
			Move (new Vector2(Dir*1200,100),5.8f);
          
        
      

		if (CheckOnTrigger ())
			Triggeraction();

		CheckOnFalling ();

		CheckOnBackPosition (false);


		if (FallingOrRunnning) {

			MakeMoveOnTheFalling ();
	
		} else 
			MakeMoveOnTheGround ();
	

	}
	  
	public void Triggeraction()
	{
		if  ((Tricks.Con_Of_WallRun_Shadow == true || Tricks.Con_Of_ShotWallRun_Shadow) && Player_Rig.velocity.y > -0.5f) {

			if (!Physics.Raycast (transform.position, Vector3.up, 2f)) {
				if(Tricks.Con_Of_WallRun)
					Player_Rig.AddForce(new Vector2(0,1500));		
				wallrun.PlayTrick2 ();
			}

		}
	
	
	
	
	}
	public void CheckOnPosition()
	{
		if (ListOfShadow.kv.Key.Count > 0)
		{
			if (Mathf.Abs(ListOfShadow.Return_key_MyDir().x - this.transform.position.x) < 0.05f
				&& Mathf.Abs(ListOfShadow.Return_key_MyDir().y - this.transform.position.y) < 0.05f
			)
			{

				action_geter(ListOfShadow.Return_Value_MyDir());
				ListOfShadow.Delete();

			}
		}
	
	
	}
}
