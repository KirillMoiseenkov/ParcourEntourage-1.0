using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickElement
{
    //must be builded
    private string trick_name;
    private Vector2 jump_force;
    private string rotate_name;
    private float anima_speed;
    private float rotateSpeed;

    //are a same for all instances
    private GameObject character;
    private Animator rotate_anims;
    private Animator tricks_anims;
    private Rigidbody character_phisic;
    private GameObject ground_checker;
    private EventGeter eventGeter;

    //what is it?(must be reinit)
    private LayerMask ignore_for_overlaps_ray;
   

    private TricksData tricksData;

    //for wall run (maybe its can change)
    public static bool Con_Of_Monkey;
    public static bool Con_Of_WallRun;
    public static bool Con_Of_ShotWallRun;
    public static bool Con_Of_WallRun_Shadow;
    public static bool Con_Of_ShotWallRun_Shadow;

    private void init()
    {
        this.character = this.tricksData.getCharacter();//GameObject.FindGameObjectWithTag(character_name);
        this.ground_checker = this.tricksData.getGroundChecker();//GameObject.FindGameObjectWithTag(ground_checker_name);
        this.character_phisic = this.tricksData.getCharacterPhisic();//this.character.GetComponent<Rigidbody>();
        this.tricks_anims = this.tricksData.getTricksAnimator();//GameObject.FindGameObjectWithTag(player_name).GetComponent<Animator>();
        this.rotate_anims = this.tricksData.getRotateAnims();//GameObject.FindGameObjectWithTag(rot_name).GetComponent<Animator>();
        this.eventGeter = this.tricksData.getEventGeter();//GameObject.FindWithTag(player_name).GetComponent<EventGeter>();

        this.ignore_for_overlaps_ray = this.tricksData.getLayerMask();
    }

    public TrickElement(TricksData tricksData)
    {
        this.tricksData = tricksData;//GameObject.FindGameObjectWithTag("data_object").GetComponent<TricksData>();
        this.init();
    }


    public void setRotateSpeed(float speed)
    {
        this.rotateSpeed = speed;
        this.rotate_anims.speed = this.rotateSpeed;
    }

    public float getRotateSpeed()
    {
        return this.rotateSpeed;
    }

    public void setTrickName(string trick_n)
    {
        this.trick_name = trick_n;
    }

    public string getTrickName()
    {
        return this.trick_name;
    }

    public void setJumpForce(Vector2 jumpForce)
    {
        this.jump_force = jumpForce;
    }

    public Vector2 getJumpForce()
    {
        return this.jump_force;
    }

    public void setRotateAnimName(string ra_name)
    {
        this.rotate_name = ra_name;
    }

    public string getRotateAnimName()
    {
        return this.rotate_name;
    }

    public void setAnimaSpeed(float s)
    {
        this.anima_speed = s;
        this.tricks_anims.speed = anima_speed;
    }

    public float getAnimaSpeed()
    {
        return this.anima_speed;
    }

    private bool groundChecker(float ray_height)
    {
        return Physics.Raycast(this.ground_checker.transform.position, -this.ground_checker.transform.up,
            ray_height, this.ignore_for_overlaps_ray);
    }

    public void jump()
    {
        this.character_phisic.AddForce(new Vector3(character.transform.forward.x * jump_force.x
            , character.transform.up.y * jump_force.y, 0), ForceMode.Impulse);
    }

    public void rotate()
    {
        this.rotate_anims.Play(this.rotate_name);
    }

    public void reInitField() {
        setAnimaSpeed(anima_speed);
        setRotateSpeed(rotateSpeed);
    }   
    
    public void playTrick()
    {
        if (tricks_anims.GetCurrentAnimatorStateInfo(0).IsName("Falling") ||
            tricks_anims.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            this.reInitField();
            this.tricks_anims.Play(this.trick_name);
        }
    }

    public override string ToString()
    {
        return "name, force, anim, type, speed \n" +
               trick_name +
               jump_force +
               rotate_name +
               //trickType +
               anima_speed;
    }


}
