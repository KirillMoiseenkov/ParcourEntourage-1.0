using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character :AbstractClassOfPlayer
{
    private TricksData tricksData;
	public bool cameraMain;
	public float time = 1;
	public string action;
	public ShadowOfPlayer SOP;
    private Data data_shadow;
	public GameObject Chara;
	public GameObject Shad;
    public Controller controller;
    private Assassin assassin;
    private DefenderDestroyer defenderDestroyer;
    public CameraBinder cameraBinder;
    public TrickAdapter trickAdapter;

	private void Awake()
	{

        trickAdapter = new TrickAdapter();

        Shad = GameObject.FindGameObjectWithTag("ShadowRot");
        Chara = GameObject.FindGameObjectWithTag("rot");
        Tricks.Con_Of_Monkey = Tricks.Con_Of_WallRun =
        Tricks.Con_Of_ShotWallRun = Tricks.Con_Of_WallRun_Shadow =
        Tricks.Con_Of_ShotWallRun_Shadow = false;

        base.Init ("player", cameraMain, true, "ground_checker", "character", "player", "rot");
        data_shadow = new Data(@"/","shadow.dat");

        if (!data_shadow.IsExist())
        {
            data_shadow.shadow = new Data.ShadowPlayer();
            data_shadow.shadow.ListOfShadow = new MyDir.KV();
            
            data_shadow.RewriteShadow();
        }
        data_shadow.shadow = data_shadow.ReadShadow();

        cameraBinder = new CameraBinder();
    }

    

    private void Start()
    {
        this.tricksData = GameObject.FindGameObjectWithTag("data_object").GetComponent<TricksData>();

        Physics.IgnoreLayerCollision(8, 9);

        this.behaviorController = new BehaviorController(this.tricksData);

        this.groundCheacker = new GroundChecker(this.tricksData);

        this.assassin = new Assassin(this.tricksData);

        this.defenderDestroyer = new DefenderDestroyer(this.tricksData);



        if (true)
        {
            this.camera_offset = new Vector3(0, 1, -6);
            //поиск главной камеры
            cam = Camera.main;
        }

        cameraBinder.init(cam,tricksData,camera_offset);

    }

    public void addTrickToQueue() {

    }

    private BehaviorController behaviorController;

    private GroundChecker groundCheacker;

    public void addElementToQueue(string picture) {

        string trickName = trickAdapter.getNameByPicture(picture);

        behaviorController.addElementToQueue(trickName);
    }

    private void Update()
	{
        
        if (groundCheacker.isGrounded(1))//if player is grounded
        {
            behaviorController.setBehaviorGround();
        }
        else
        {
            behaviorController.setBehaviorFall();
        }

        behaviorController.execute();

        if (controller.canWallRun) 
		    if ( (Tricks.Con_Of_WallRun == true || Tricks.Con_Of_ShotWallRun) 
                && Player_Rig.velocity.y > -0.5f)
			 {
			    if (!Physics.Raycast (transform.position, Vector3.up, 2f))
                {
				    if(Tricks.Con_Of_WallRun)
					    Player_Rig.AddForce(new Vector2(0,1500));
				    wallrun.PlayTrick ();
			    }
		    }
        

		Move (new Vector2(Dir*1200,100),5.8f);

    }

    private void FixedUpdate()
    {
        cameraBinder.cameraUpdate();
    }


}
