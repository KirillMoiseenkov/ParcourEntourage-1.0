using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {


	//public	TriggerAction TriggerBool;
	public GameObject pointOfEdge;
	private EventGeter eventGeterPlayer;
	private EventGeter eventGeterShadow;
    private Vector3 heightestPos;

	void Start()
	{
		eventGeterPlayer = GameObject.FindGameObjectWithTag ("player").GetComponent<EventGeter>();
		eventGeterShadow = GameObject.FindGameObjectWithTag ("ShadowPlayer").GetComponent<EventGeter>();
	}

	void OnTriggerEnter(Collider MyTrigger)
	{

        heightestPos = new Vector3(MyTrigger.transform.position.x, MyTrigger.transform.position.y + 4.1f,
        MyTrigger.transform.position.z);
        Ray ray_side_s = new Ray(heightestPos, MyTrigger.transform.forward);
        Ray ray_up_s = new Ray(MyTrigger.transform.position, MyTrigger.transform.up);
        if (!(Physics.Raycast(ray_side_s, 1)) && !(Physics.Raycast(ray_up_s, 4.5f)))//debag in EventGeter class
            if (MyTrigger.gameObject.name == "ShadowRot") {
            
            switch (this.gameObject.tag) {
			case "Monkey":
                        
                    eventGeterShadow.pointOfEdge = this.pointOfEdge;

				if ((pointOfEdge.transform.position.y - MyTrigger.gameObject.transform.position.y) < 5)
				if ((pointOfEdge.transform.position.y - MyTrigger.gameObject.transform.position.y) > 2)
					Tricks.Con_Of_WallRun_Shadow = true;
				else{
					Tricks.Con_Of_ShotWallRun_Shadow = true;	
				
				}


				break;

			}
		}

        if (MyTrigger.gameObject.name == "rot")// && 	Tricks.Con_Of_WallRun == false && Tricks.Con_Of_ShotWallRun == false)
        {
            heightestPos = new Vector3(MyTrigger.transform.position.x, MyTrigger.transform.position.y + 5.1f,
                MyTrigger.transform.position.z);
            Ray ray_side = new Ray(heightestPos, MyTrigger.transform.forward);
            Ray ray_up = new Ray(MyTrigger.transform.position, MyTrigger.transform.up);
            if (!(Physics.Raycast(ray_side, 1)) && !(Physics.Raycast(ray_up, 6.5f)))
            {
                switch (this.gameObject.tag)
                {
                    case "Monkey":
                        eventGeterPlayer.pointOfEdge = this.pointOfEdge;
                        if ((pointOfEdge.transform.position.y - MyTrigger.gameObject.transform.position.y) < 5)
                            if ((pointOfEdge.transform.position.y - MyTrigger.gameObject.transform.position.y) > 2)
                                Tricks.Con_Of_WallRun = true;
                            else
                            {
                                Tricks.Con_Of_ShotWallRun = true;

                            }


                        break;

                }
            }
        }
	 
	}
	void OnTriggerExit(Collider MyTrigger)
	{
        if (MyTrigger.gameObject.name == "rot")
        {
            switch (this.gameObject.tag)
            {
                case "Monkey":
                    Tricks.Con_Of_Monkey = false;
                    Tricks.Con_Of_WallRun = false;
                    Tricks.Con_Of_ShotWallRun = false;
                    break;
            }
        }
        if (MyTrigger.gameObject.name == "ShadowRot")
        {
            switch (this.gameObject.tag)
            {
                case "Monkey":
                    Tricks.Con_Of_Monkey = false;
                    Tricks.Con_Of_ShotWallRun_Shadow = false;
                    Tricks.Con_Of_WallRun_Shadow = false;
                    break;
            }
        }
	
	
	}













}
