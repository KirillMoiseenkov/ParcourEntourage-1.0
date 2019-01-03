using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITrick
{
    void init();
    void jump();
    void playTrick();
    void rotate();
}


[System.Serializable]
public class Tricks : MonoBehaviour
{
	
	public string ground_checker_name = "ground_checker";
	public string character_name = "character";
	public string player_name = "player";
	public string rot_name = "rot";
	public static bool Con_Of_Monkey;
	public static bool Con_Of_WallRun;
	public static bool Con_Of_ShotWallRun;
	public static bool Con_Of_WallRun_Shadow;
	public static bool Con_Of_ShotWallRun_Shadow;
    private LayerMask ignore_for_overlaps_ray;

    public string trick_name;
	public Vector2 jump_force;
	public GameObject character;
   // protected CharacterMain characterMain;

    [SerializeField]
	public Animator rotate_anims;
    [SerializeField]
	public Animator tricks_anims;
    [SerializeField]
    protected Rigidbody character_phisic;

    [SerializeField]
	public GameObject ground_checker_pos;
    public EventGeter eventGeter;



	public void TricksInit(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	
	}

	public virtual void Init()
		
    {
		this.character = GameObject.FindGameObjectWithTag(character_name);
		this.ground_checker_pos = GameObject.FindGameObjectWithTag(ground_checker_name);
		this.character_phisic = this.character.GetComponent<Rigidbody>();
		this.tricks_anims = GameObject.FindGameObjectWithTag(player_name).GetComponent<Animator>();
		this.rotate_anims = GameObject.FindGameObjectWithTag(rot_name).GetComponent<Animator>();
		this.eventGeter = GameObject.FindWithTag(player_name).GetComponent<EventGeter>();

        this.ignore_for_overlaps_ray = new LayerMask();
        this.ignore_for_overlaps_ray = 1 << LayerMask.NameToLayer("Default");

    }
	public void ChangeJump(Vector2 Value)
	{
		this.jump_force = Value;


	}

    public bool GroundChecker(float ray_height)
    {
        /*
        Collider[] col = Physics.OverlapSphere(this.ground_checker_pos.transform.position, radius, ignore_for_overlaps_ray);
        //print(col.Length);
        Debug.DrawLine(this.ground_checker_pos.transform.position, new Vector3(this.ground_checker_pos.transform.position.x,
           this.ground_checker_pos.transform.position.y - radius, this.ground_checker_pos.transform.position.z));
        Debug.DrawLine(this.ground_checker_pos.transform.position, new Vector3(this.ground_checker_pos.transform.position.x,
            this.ground_checker_pos.transform.position.y, this.ground_checker_pos.transform.position.z - radius));
            */
        return Physics.Raycast(this.ground_checker_pos.transform.position, -this.ground_checker_pos.transform.up, 
            ray_height, ignore_for_overlaps_ray);
    }
    
    public virtual void Lending()
    {
        this.character_phisic.velocity = Vector3.zero;
    }

    public virtual void Jump()
    {
        //character.GetComponent<Collider>().enabled = false;
		if(this.GroundChecker(0.4f))
        this.character_phisic.AddForce(new Vector3(character.transform.forward.x * jump_force.x
            ,character.transform.up.y * jump_force.y,0),ForceMode.Impulse);
    }
    public virtual void PlayTrick()
    {
            this.eventGeter.jump_method = this.Jump;
            this.tricks_anims.Play(this.trick_name);
    }
    public virtual void Rotate()
    {
        this.rotate_anims.Play("Rotate_forward");
    }
    public void rotate(float x,float y,float z)
    {
        this.character.transform.rotation = Quaternion.Euler(new Vector3(x,y,z));
    }



}


[System.Serializable]
public class ForwardFlip : Tricks, ITrick
{
	
	public ForwardFlip(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}

	}

    /*
    public override void Init()
    {
    }
    */

    public void init()
    {
        base.Init();
        this.trick_name = "forward_flip";
        this.rotate_anims.speed = 1f;

        this.jump_force = new Vector2(50, 250);
    }

    /*
    public override void Jump()
    {

    }
    */

    public void jump()
    {
        base.Jump();
        this.Rotate();
    }
    /*
    public override void PlayTrick()
    {
        //this.rotate_anims.speed = 0.7f;

        //base.PlayTrick();

        if (this.GroundChecker(0.4f))
        {
            this.rotate_anims.speed = 1f;
            this.eventGeter.rotate_method = this.Rotate;
            this.eventGeter.jump_method = this.Jump;
            this.tricks_anims.Play(this.trick_name);
        }

    }
    */
    public void playTrick()
    {
        if (this.GroundChecker(0.4f))
        {
            this.rotate_anims.speed = 1f;
            this.eventGeter.rotate_method = this.Rotate;
            this.eventGeter.jump_method = this.Jump;
            this.tricks_anims.Play(this.trick_name);
        }
    }

    public void rotate()
    {
    }
}
[System.Serializable]

public class Running : Tricks
{
	
	private float move_speed;
	private static int run_hash;
	public Running(float _move_speed, bool OnOff, string ground_checker, string character,string player, string rot)
	{ 
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
		this.trick_name = "run";
		this.move_speed = _move_speed;
	}

	public override void Init()
	{
		base.Init();
		run_hash = this.tricks_anims.GetCurrentAnimatorStateInfo(0).nameHash;
		this.jump_force = new Vector2(1000, 0);
	}

	public override void Jump ()
	{
		base.Jump ();
		
	}


	public void Run()
	{
		
		//this.character.transform.position += this.character.transform.forward * this.move_speed * Time.deltaTime;
	}


	public override void PlayTrick()
	{

			if (base.GroundChecker (0.4f) && this.tricks_anims.GetCurrentAnimatorStateInfo (0).nameHash == run_hash) {

				
				this.tricks_anims.SetBool (this.trick_name, true);
				this.Run ();            
			} 

	}


}


	



public class Falling : Tricks
{
	public Falling(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}

	public override void Init()
	{
	
		base.Init();
		this.trick_name = "Falling";

	}

	public override void PlayTrick()
	{
		
			this.tricks_anims.Play(this.trick_name);

	}
}

[System.Serializable]
public class Rondate : Tricks
{
	public Rondate(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}


	public override void Init()
	{
		base.Init();
		this.trick_name = "rondate";
	}
	public override void PlayTrick()
	{
		if (base.GroundChecker(0.4f))
		{
			this.tricks_anims.Play(this.trick_name);
		}
	}
}
[System.Serializable]


public class Flyag : Tricks
{

	public Flyag(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}



    public override void PlayTrick()
    {
    
		this.tricks_anims.Play (this.trick_name);
	}
    public override void Init()
    {
	     base.Init();
        this.trick_name = "flyag";
        this.jump_force = new Vector3(10,250,0);
    }
    public override void Rotate()
    {
        this.rotate_anims.Play("flyag_rotate");
    }
    public override void Jump()
    {
        base.Jump();
        this.eventGeter.rotate_method += this.Rotate;
    }
}
[System.Serializable]
public class BackFlip : Tricks
{ 
	public BackFlip(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}

    public override void Init()
    {
	     base.Init();
        this.trick_name = "back_flip";
        this.jump_force = new Vector3(250,350);
    }
    public override void Rotate()
    {
        this.rotate_anims.Play("Rotate_forward");
    }
    public override void Jump()
    {
        base.Jump();
    }
    public override void PlayTrick()
    {
		this.rotate_anims.speed = 0.65f;
        if (base.GroundChecker(0.4f))
        {
            this.tricks_anims.SetBool("run", false);
            this.eventGeter.jump_method = this.Jump;
            this.eventGeter.rotate_method = this.Rotate;
            this.tricks_anims.Play(this.trick_name + "_begin");
        }
    }
}
[System.Serializable]
public class Arabh : Tricks
{
	public Arabh(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}

    public override void Init()
    {
	   base.Init();
        this.trick_name = "arabh_first_stage";
       
        this.jump_force = new Vector2(50, 300);
    }
    public override void Jump()
    {
        base.Jump();
        this.Rotate();
    }
	public override void PlayTrick()
	{
		if (this.GroundChecker(0.4f) )
		{
			this.rotate_anims.speed = 0.7f;
			this.eventGeter.rotate_method = this.Rotate;
			this.eventGeter.jump_method = this.Jump;
			this.tricks_anims.Play(this.trick_name);
		}
	}
}

[System.Serializable]
public class Screw : Tricks
{
	public Animator Rotating;

	public Screw(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
			this.Rotating  = GameObject.FindGameObjectWithTag(rot).GetComponent<Animator>();

		}
	}

    public override void Init()
    {
	    base.Init();
        
		this.trick_name = "screw";
		this.jump_force = new Vector2(50, 350);
    }
    public override void Rotate()
    {
		this.rotate_anims.Play("Rotate_forward");
    }
    public override void PlayTrick()
    {
        if (this.GroundChecker(0.4f) )
        {
			this.rotate_anims.speed = 0.5f;
			this.eventGeter.rotate_method = this.Rotate;
            this.eventGeter.jump_method = this.Jump;
            this.tricks_anims.Play(this.trick_name);
        }
    }
}
[System.Serializable]
public class Blansh : Tricks
{
	public Animator Rotating;
	public Blansh(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
			this.Rotating  = GameObject.FindGameObjectWithTag(rot).GetComponent<Animator>();

		}

	}

    public override void Init()
    {
	   base.Init();
        this.trick_name = "blansh";
        this.jump_force = new Vector3(50, 460);
    }
    public override void Rotate()
    {
		this.rotate_anims.Play("Rotate_forward");
    }
    public override void PlayTrick()
    {
		if (this.GroundChecker(0.4f))
        {
			this.rotate_anims.speed = 0.4f;
			this.eventGeter.rotate_method = this.Rotate;
            this.eventGeter.jump_method = this.Jump;
            this.tricks_anims.Play(this.trick_name);
        }
    }
}
[System.Serializable]
public class SideFlip : Tricks
{
    public SideFlip(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}

    public override void Init()
    {
	   base.Init();
		this.trick_name = "SideFlip-1";
        this.jump_force = new Vector2(50, 350);
		this.rotate_anims.speed = 0.6f;

	}
    public override void Jump()
    {
        base.Jump();
        this.Rotate();
    }

    public override void PlayTrick()
    {
        if (this.GroundChecker(0.4f))
        {
            this.rotate_anims.speed = 1f;
            this.eventGeter.rotate_method = this.Rotate;
            this.eventGeter.jump_method = this.Jump;
            this.tricks_anims.Play(this.trick_name);
        }
    }
}




public class SimpleJump : Tricks
{
	public SimpleJump(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}

	public override void Init()
	{
		base.Init();
		this.trick_name = "SimpleJump";
		this.jump_force = new Vector2(20, 120);
	}
	public override void Jump()
	{
		base.Jump();
	}

	public override void PlayTrick()
	{
		if (base.GroundChecker(0.4f))
		{

			this.eventGeter.jump_method = this.Jump;
			this.tricks_anims.Play(this.trick_name);
			this.jump_force = new Vector2 (50, 100);
			this.eventGeter.jump_method = this.Jump;
		}
	}




}




///////////////////////////      Triegger Action


public class Monkey:Tricks
{

	public Monkey(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}

   public override void Init()
	{
		base.Init();
		this.jump_force = new Vector2(300,20);
		this.trick_name = "Monkey";
	}
	public override void Jump()
	{
		base.Jump();
		
	}
	public override void PlayTrick()
	{
		if (base.GroundChecker(0.4f)  && (Con_Of_Monkey == true) )
		{
			//this.tricks_anims.SetBool("run", false);
			this.eventGeter.jump_method = this.Jump;
			this.tricks_anims.Play(this.trick_name);
		}
	}

}

public class WallRun:Tricks
{
	public WallRun(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}


	public override void Init()
	{
		base.Init();

		this.jump_force = new Vector2(0,300);
		this.trick_name = "WallRun";

	}
	public override void Jump()
	{
		base.Jump();

	}
	public void PlayTrick2()
	{
        if (Con_Of_WallRun_Shadow)
        {
            eventGeter.IsDangerEnd();
            this.tricks_anims.Play (this.trick_name);
        }
        else
        {
            if (Con_Of_ShotWallRun_Shadow)
            {
                eventGeter.IsDangerEnd();
                this.tricks_anims.Play("WallRun 0");
            }
        }

        eventGeter.jump_method = this.Jump;
	
	}
	public override void PlayTrick()
	{
        //print("Wall run was played!");
        if (Con_Of_WallRun)
        {
            eventGeter.IsDangerEnd();
            this.tricks_anims.Play (this.trick_name);
		}
        else
        {
            if (Con_Of_ShotWallRun)
            {
                eventGeter.IsDangerEnd();
                this.tricks_anims.Play("WallRun 0");
            }
        }

        eventGeter.jump_method = this.Jump;

    }

}

///// ActionOnThefalling

public class TakeTheGroup:Tricks
{
	public TakeTheGroup(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	}

	public override void Init()
	{
		base.Init();
		this.trick_name = "TGOF";
		this.jump_force = new Vector2(250,0);
	}
	public override void Jump()
	{
		base.Jump();

	}



	public override void PlayTrick ()
	{
		
		this.eventGeter.jump_method = this.Jump;

		this.tricks_anims.Play(this.trick_name);
	}


}

public class ForwardFlip_On_The_Falling : Tricks
{
	bool Dir = true;
	public ForwardFlip_On_The_Falling(bool OnOff, string ground_checker, string character,string player, string rot)
	{
		
		if (OnOff) {  
			ground_checker_name = ground_checker;
			character_name = character;
			player_name = player;
			rot_name = rot;
		}
	
	}
	public override void Rotate()
	{
	//	this.rotate_anims.Play("Rotate_forward");
		if(Dir)
			this.rotate_anims.Play("Rotate_forward");
		else
			this.rotate_anims.Play("Rotate_Back_true");
		
	}
	public void DirOfRotate(bool Dir)
	{
		this.Dir = Dir;

	
	}
	public override void Init()
	{
		
		base.Init();
		this.trick_name = "ForwardFlip_F";
	}
/*	public override void Jump()
	{
		this.Rotate();
	}
*/
	public override void PlayTrick ()
	{
		
		//this.Rotate ();
        this.eventGeter.rotate_method = this.Rotate;
        tricks_anims.Play (this.trick_name);
	}
}