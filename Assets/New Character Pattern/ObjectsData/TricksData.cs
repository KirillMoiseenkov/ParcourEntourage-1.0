using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricksData : MonoBehaviour
{

    //constants
    private const string ground_checker_name = "ground_checker";
    private const string character_name = "character";
    private const string player_name = "player";
    private const string rot_name = "rot";

    //are a same for all instances
    private GameObject character;
    private Animator rotate_anims;
    private Animator tricks_anims;
    private Rigidbody character_phisic;
    private GameObject ground_checker;
    private EventGeter eventGeter;

    //what is it?(must be reinit)
    private int ignore_for_overlaps_ray;

    public void Awake()
    {
        this.character = GameObject.FindGameObjectWithTag(character_name);
        this.ground_checker = GameObject.FindGameObjectWithTag(ground_checker_name);
        this.character_phisic = this.character.GetComponent<Rigidbody>();
        this.tricks_anims = GameObject.FindGameObjectWithTag(player_name).GetComponent<Animator>();
        this.rotate_anims = GameObject.FindGameObjectWithTag(rot_name).GetComponent<Animator>();
        this.eventGeter = GameObject.FindWithTag(player_name).GetComponent<EventGeter>();
        //Debug.Log(this.eventGeter);

        print(this.ground_checker);

        this.ignore_for_overlaps_ray = new LayerMask();
        this.ignore_for_overlaps_ray = (1 << LayerMask.NameToLayer("Default"));
    }

    public GameObject getCharacter()
    {
        return this.character;
    }

    public Animator getRotateAnims()
    {
        return this.rotate_anims;
    }

    public Animator getTricksAnimator()
    {
        return this.tricks_anims;
    }

    public Rigidbody getCharacterPhisic()
    {
        return this.character_phisic;
    }

    public GameObject getGroundChecker()
    {
        return this.ground_checker;
    }

    public EventGeter getEventGeter()
    {
        return this.eventGeter;
    }

    public int getLayerMask()
    {
        return this.ignore_for_overlaps_ray;
    }
}
