using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool isDeath = false;
    public EventGeter eventGeter;
    [SerializeField]
    private Collider this_collider;
    private Animator anima_player;
    private Animator anima_rot;
    private Rigidbody rigb;
    private GameObject character;
    private Character characterMain;
    private AbstractClassOfPlayer acop;
    private GameObject body;
    private GameObject MeshPoint;
    private GameObject[] gos = new GameObject[12];
    private Collider[] bodys = new Collider[12];

    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("character");
        characterMain = character.GetComponent<Character>();
        anima_rot = GameObject.FindGameObjectWithTag("rot").GetComponent<Animator>();
        rigb = character.GetComponent<Rigidbody>();
        body = GameObject.FindGameObjectWithTag("player");
        MeshPoint = GameObject.FindGameObjectWithTag("PlayerMesh");
        anima_player = body.GetComponent<Animator>();
        eventGeter = body.GetComponent<EventGeter>();
        acop = character.GetComponent<AbstractClassOfPlayer>();
        gos = GameObject.FindGameObjectsWithTag("body");
        for (int i = 0; i < 11; i++)
            bodys[i] = gos[i].GetComponent<Collider>();
    }

    private void Update()
    {
        if (isDeath)
        {
            anima_player.enabled = false;
            anima_rot.enabled = false;
            //rigb.velocity = new Vector3(0f,-9.8f,0f);
            //rigb.AddForce(-100f, 0f, 0f);
            //rigb.useGravity = false;
            characterMain.cameraMain = false;
            acop.CameraFix(MeshPoint);
            for (int i = 0; i < 11; i++)
                bodys[i].enabled = true;
        }
    }
}
