using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  AbstractClassOfPlayer : MonoBehaviour
{
    private LayerMask ignore_for_overlaps_ray;
	protected int Dir = 1;
	public int score = 0;
	[SerializeField]
	protected float graund_checker_radius;
    private Death character_death;
	public Tricks tricks;
	public EventGeter PlayerEvents;
	protected ForwardFlip forwardFlip;
	protected Running running;
	protected TakeTheGroup Take_The_Group;
	protected Rondate rondate;
	protected Screw screw;
	protected Flyag flyag;
	protected BackFlip backFlip;
	protected Arabh arabh;
	protected Blansh blansh;
	protected SideFlip sideFlip;
	protected WallRun wallrun;
	protected Falling falling;
	protected ForwardFlip_On_The_Falling FFOTF;
	//private TriggerAction TriggerMove;
	protected SimpleJump Jumping;
	protected Monkey monkey;
	public Animator Rotate;
	public Animator tricks_anims;
	public string new_action;
	protected Vector2 Lim_Force;
	public Vector2 force;
	protected const string WallRun = "Allah";
    //public GameObject FallingDeathTrigger;
	protected const string TTG = "s-9-91";
	protected const string Jumping_name = "s-9-9";
	protected const string Monkey_name = "s9";
	protected const string forward_flip_name = "s1199";
	protected const string rondate_flip_name = "s1199-1";
	protected const string flyag_flip_name = "s19";
	protected const string back_flip_name = "s-1-199";
	protected const string arabh_flip_name = "s11999";
	protected const string screw_flip_name = "s1199-1-1";
	protected const string blansh_flip_name = "s-1-1999";
	protected const string side_flip_name = "s-9-911";
	protected const string to_left = "s-1-1";
	protected const string to_right = "s11";
	protected Camera cam;
	protected bool is_grounded = false;
	public bool FallingOrRunnning;
	public float move_speed;
	[SerializeField]
	public bool vary;
	protected Vector3 camera_offset;
	[SerializeField]
	private ColliderFit colliderFit;
	protected Animator animator;
	protected GameObject player;
	protected Rigidbody Player_Rig;
	protected bool is_played_no_jump_anima;
	protected string last_anima;
    public MyDir ListOfShadow = new MyDir();
	//public Dictionary<Data.point,string> ListOfShadow = new Dictionary<Data.point,string>();
	protected float Buf;

	public bool Condition_of_trigger = false;
    public GameObject controled_character;
    public GameObject controled_rot;
    public CollisionDetect col_det;

	protected Queue<string> tricks_queue = new Queue<string>();

	public void action_geter(string action)
	{
		this.tricks_queue.Enqueue(action);
	}






	public void Init(string NameOfPlayer, bool Cam_offset, bool OnOff,string Ground_checker, string character,string Player, string rot)
	{
        Time.timeScale = 1;
        this.ignore_for_overlaps_ray = new LayerMask();
        this.ignore_for_overlaps_ray = 1;//<< LayerMask.NameToLayer("Defoult");
        this.controled_rot = GameObject.FindGameObjectWithTag(rot);
        //this.falling_time = 0;
		this.tricks_anims = GameObject.FindGameObjectWithTag(NameOfPlayer).GetComponent<Animator>();
		player = GameObject.Find(NameOfPlayer);
        this.PlayerEvents = player.GetComponent<EventGeter>();
		this.Rotate  = this.controled_rot.GetComponent<Animator>();
        this.controled_character = GameObject.FindGameObjectWithTag(character);
        this.last_fall = this.controled_character.transform.position.y;
        this.Player_Rig = this.controled_character.GetComponent<Rigidbody> ();
        this.falling_sum = 0f;
        
        //character_death = Rotate.gameObject.GetComponent<Death>();

        this.character_death = GameObject.FindWithTag(character).GetComponent<Death>();
        this.col_det = controled_rot.GetComponent<CollisionDetect>();

        animator = player.GetComponent<Animator>();

		if (true) {
			this.camera_offset = new Vector3 (0, 1, -6);
			//поиск главной камеры
			cam = Camera.main;
		}


		tricks = new Tricks();
		tricks.TricksInit(OnOff,Ground_checker,character,Player, rot);
		tricks.Init();

		wallrun = new WallRun(OnOff,Ground_checker,character,Player, rot);
		wallrun.Init();



		forwardFlip = new ForwardFlip(OnOff,Ground_checker,character,Player, rot);
		forwardFlip.Init();

		running = new Running(move_speed, OnOff,Ground_checker,character,Player, rot);
		running.Init();

		rondate = new Rondate(OnOff,Ground_checker,character,Player, rot);
		rondate.Init();

		flyag = new Flyag(OnOff,Ground_checker,character,Player, rot);
		flyag.Init();
	
		backFlip = new BackFlip(OnOff,Ground_checker,character,Player, rot);
		backFlip.Init();
	
		arabh = new Arabh(OnOff,Ground_checker,character,Player, rot);
		arabh.Init();
	
		screw = new Screw(OnOff,Ground_checker,character,Player, rot);
		screw.Init();
	
		blansh = new Blansh(OnOff,Ground_checker,character,Player, rot);
		blansh.Init();
	
		sideFlip = new SideFlip(OnOff,Ground_checker,character,Player, rot);
		sideFlip.Init();
	
		Jumping = new SimpleJump(OnOff,Ground_checker,character,Player, rot);
		Jumping.Init();
	


		//Trigger
		monkey = new Monkey(OnOff,Ground_checker,character,Player, rot);
		monkey.Init();

		//Falling
		falling = new Falling(OnOff,Ground_checker,character,Player, rot);
		falling.Init();
	
		FFOTF = new ForwardFlip_On_The_Falling (OnOff, Ground_checker, character, Player, rot);
		FFOTF.Init();

		Take_The_Group = new TakeTheGroup(OnOff,Ground_checker,character,Player, rot);
		Take_The_Group.Init ();
	


		colliderFit = tricks.rotate_anims.gameObject.GetComponent<ColliderFit>();
        //this.offset_capsule = new Vector3(0.1f,0.95f,0f);


        raycasted_col = new Collider[0];


    }
    public void Move(Vector2 force, float Lim)
	{

        Lim_Force = new Vector2 (Lim, 0);	
		if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("run")) {
			if (this.Player_Rig.velocity.magnitude < Lim) {
				if (this.Player_Rig.velocity.magnitude < Lim / 3)
					this.Player_Rig.AddForce (force);
				else
					this.Player_Rig.AddForce (force / 2);
				this.Player_Rig.AddForce (new Vector2(0,300));


			
			}
		} else if (this.animator.GetCurrentAnimatorStateInfo (0).IsName (rondate.trick_name) || this.animator.GetCurrentAnimatorStateInfo (0).IsName (flyag.trick_name)) {
			if (Player_Rig.velocity.magnitude < Lim / 1.2) {
				this.Player_Rig.AddForce (force);
			
			}
			
		
		} else if (this.animator.GetCurrentAnimatorStateInfo (0).IsName (Take_The_Group.trick_name) ) {
			this.Player_Rig.AddForce (force / 3);
		
		}

	
	}
	
    public void CameraFix(GameObject FixedPoint)
    {
        this.camera_offset = new Vector3(0, 0, -6);
        cam.transform.position = this.camera_offset + FixedPoint.transform.position;
    }

	public void CheckOnBackPosition(bool cambool)
	{
	    //this.is_played_no_jump_anima = this.animator.GetCurrentAnimatorStateInfo(0).IsName(rondate.trick_name);
	    //if (this.is_played_no_jump_anima) running.Run();
		//if(cambool)
		//    cam.transform.position = this.camera_offset + tricks.character.transform.position;
		//is_grounded = tricks.GroundChecker(graund_checker_radius);
		//colliderFit.fit = !is_grounded;

	}

	public bool PreCheckOnFalling()
	{
        if (!tricks.GroundChecker(0.4f))
        {
            FallingOrRunnning = true;
        }
        else
        {
            FallingOrRunnning = false;
        }		
        
		return 	FallingOrRunnning;
	}

    private float falling_sum = 0.0f;
    private float last_fall = 0.0f;
    private float delta_fall = 0.0f;
    private float last_vel = 0.0f;
    private float delta_vel = 0.0f;
    private bool b = true;

    public void CheckOnFalling()
	{
        //print(falling_sum + " " + delta_vel);
		if (!tricks.GroundChecker(0.4f) && this.animator.GetCurrentAnimatorStateInfo (0).IsName ("run"))
        {
			if (!tricks.eventGeter.anima_is_play) 
			    if(!tricks.GroundChecker (0.4f))
                {
				    tricks_anims.SetBool ("Falling", true);
				    FallingOrRunnning = true;
				    falling.PlayTrick ();
			    }
        }

        //код ниже - важен. без него не будет работать смерть от стены!
        if (!tricks.GroundChecker(0.4f) || this.animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            //print("OnFalling!");
            delta_vel = Player_Rig.velocity.y + last_vel;
            if (delta_vel < 0f)
            {
                if (b) { last_fall = controled_character.transform.position.y; b = false; }
                //print("delta_vel < 0");
                if (touchTheWall)
                {
                    PlayerEvents.IsDangerBegin();
                    //character_death.isDeath = true;
                }
            }
            last_vel = Player_Rig.velocity.y;
            delta_vel = 0f;
            //print("delta vel = " + delta_vel);
        }
        //

        if (tricks.GroundChecker (0.4f))
		{
            falling_sum = Mathf.Abs(last_fall - controled_character.transform.position.y);
            b = true;
            character_death.isDeath = falling_sum > 6;
			tricks_anims.SetBool ("Falling", false);
			FallingOrRunnning = false;
			falling_sum = 0.0f;
        }
    }

	private void CleanTheQueue()
    {   
		while (tricks_queue.Count != 0)
        {
			tricks_queue.Dequeue ();
		}
	}

	public bool CheckOnTrigger()
	{
		if (tricks_queue.Count == 0) {
		
		
			last_anima = "";

		} else if (!tricks.eventGeter.anima_is_play)
		if (tricks_queue.Peek () == "WallRun")
			return true;
		 
		return false;
	
	
	}
    private Collider[] raycasted_col;
    private bool touchTheWall = false;

    private bool wallRunPredecat()
    {
        return (this.animator.GetCurrentAnimatorStateInfo(0).IsName("run"));
    }

    int init = 0;

    RaycastHit falling_collider_info;
    public void CheckFallingCollision()
    {
        init++;
        //print(this.PlayerEvents.isSlide + " " + i);

        if (Physics.SphereCast(this.transform.position, 0.2f, this.transform.forward,
            out falling_collider_info, ignore_for_overlaps_ray))
        {
            //print("touchTheWall = true");
            //print(hit.collider.gameObject.tag);
            if (falling_collider_info.collider.gameObject.tag == "location"
                && !(this.PlayerEvents.isSlide))
            {
                touchTheWall = true;
                //controled_character.GetComponent<Rigidbody>().AddForce(
                //-50000 * this.controled_character.transform.right);
            }


        }
    }

    public void MakeMoveOnTheFalling()
	{
        //print(Player_Rig.velocity);

        if (tricks_queue.Count == 0) {

			if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Falling"))
				last_anima = "";
		} else {

			if ((!tricks.eventGeter.anima_is_play) || this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Falling"))
			{
				
				switch (tricks_queue.Peek ()) {

				case "s11":
					FallingOrRunnning = false;
					FFOTF.DirOfRotate (true);

					FFOTF.PlayTrick ();
					new_action = "";
					last_anima = tricks_queue.Dequeue ();

					break;
				case "s-1-1":
					FallingOrRunnning = false;
					FFOTF.DirOfRotate (false);

					FFOTF.PlayTrick ();
					new_action = "";
					last_anima = tricks_queue.Dequeue ();
					break;

				default:

					last_anima = tricks_queue.Dequeue ();
					break;
				}
			} 
		}//ifCount=0;



		//CleanTheQueue ();


	}

	public void MakeMoveOnTheGround()
	{

        if ((!tricks.eventGeter.anima_is_play) || this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Falling"))
		if (tricks_queue.Count == 0) {

			running.PlayTrick ();
			if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("run"))
				last_anima = "";
		}

		 
		if ( (!tricks.eventGeter.anima_is_play || this.animator.GetCurrentAnimatorStateInfo (0).IsName ("run")))	
            if(tricks_queue.Count != 0)
			switch (tricks_queue.Peek ()) {
			case Monkey_name:
				monkey.PlayTrick ();	 
				last_anima = this.tricks_queue.Dequeue ();
			break;

			case Jumping_name:
			
				Jumping.PlayTrick ();
				last_anima = this.tricks_queue.Dequeue ();

			break;

			case forward_flip_name:
				if (this.Player_Rig.velocity.magnitude > 1f) {
				
					forwardFlip.PlayTrick ();

					new_action = "";
					//	tricks.Lending ();
					last_anima = this.tricks_queue.Dequeue ();
				}
			break;
			case rondate_flip_name:
				rondate.PlayTrick ();
				new_action = "";
				last_anima = this.tricks_queue.Dequeue ();

			break;
			
			case flyag_flip_name:
			if (last_anima == rondate_flip_name || last_anima == back_flip_name || last_anima == flyag_flip_name) 
				{
					
					flyag.PlayTrick ();
					new_action = "";
					last_anima = this.tricks_queue.Dequeue ();
				}else
					last_anima = this.tricks_queue.Dequeue ();


			break;
			
			case back_flip_name:
				if (last_anima == rondate_flip_name || last_anima == back_flip_name || last_anima == flyag_flip_name) {
					backFlip.PlayTrick ();
					new_action = "";
					tricks.Lending ();
					last_anima = this.tricks_queue.Dequeue ();

				} else {
					last_anima = this.tricks_queue.Dequeue ();

				}
			break;
			
			case screw_flip_name:
				//if (last_anima == flyag_flip_name) {
					screw.PlayTrick ();
					new_action = "";
					last_anima = this.tricks_queue.Dequeue ();

				//} else 
				//	last_anima = this.tricks_queue.Dequeue ();


			break;
			
			case arabh_flip_name:
				arabh.PlayTrick ();
				new_action = "";
			//	tricks.Lending ();
				last_anima = this.tricks_queue.Dequeue ();

			break;
			
			case blansh_flip_name:
				if (last_anima == flyag_flip_name) {
				    
				    
					blansh.PlayTrick ();
				    new_action = "";
					last_anima = this.tricks_queue.Dequeue ();

				} else {
					last_anima = this.tricks_queue.Dequeue ();

				}
			break;
			
			case side_flip_name:
				if (this.Player_Rig.velocity.magnitude > 2f) {
					sideFlip.PlayTrick ();
					new_action = "";
					last_anima = this.tricks_queue.Dequeue ();
				}
			break;
			
			case to_left:
				//if (tricks.GroundChecker (0.4f))
				Dir = -1;  
				PlayerEvents.dir = -1;
					tricks.rotate (0, -90, 0);
				new_action = "";
				last_anima = this.tricks_queue.Dequeue ();

			break;
			
			case to_right:
				//if (tricks.GroundChecker (0.4f))
				Dir=1;
				PlayerEvents.dir = 1;
				tricks.rotate (0, 90, 0);
				new_action = "";
				last_anima = this.tricks_queue.Dequeue ();

			break;
			
			default:
				last_anima = this.tricks_queue.Dequeue ();

			break;
			}
	}

}




