using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : MonoBehaviour {




	//public bool Con_Of_Monkey = false;
	public static bool Con_Of_Monkey = false;

	public string trick_name;
	public Vector2 jump_force;
	public GameObject character;
	protected CharacterMain characterMain;

	[SerializeField]
	public Animator rotate_anims;
	[SerializeField]
	public Animator tricks_anims;
	[SerializeField]
	protected Rigidbody character_phisic;

	[SerializeField]
	private GameObject ground_checker_pos;
	public EventGeter eventGeter;




	public virtual void Init()
	{
		this.character = GameObject.FindGameObjectWithTag("character");
		this.ground_checker_pos = GameObject.FindGameObjectWithTag("ground_checker");
		this.character_phisic = this.character.GetComponent<Rigidbody>();
		this.tricks_anims = GameObject.FindGameObjectWithTag("player").GetComponent<Animator>();
		this.rotate_anims = GameObject.FindGameObjectWithTag("rot").GetComponent<Animator>();
		this.eventGeter = GameObject.FindWithTag("player").GetComponent<EventGeter>();
		this.characterMain = this.character.GetComponent<CharacterMain>();
	}

	public bool GroundChecker(float radius)
	{
		Collider[] col = Physics.OverlapSphere(this.ground_checker_pos.transform.position, radius);
		Debug.DrawLine(this.ground_checker_pos.transform.position, new Vector3(this.ground_checker_pos.transform.position.x,
			this.ground_checker_pos.transform.position.y - radius, this.ground_checker_pos.transform.position.z));
		Debug.DrawLine(this.ground_checker_pos.transform.position, new Vector3(this.ground_checker_pos.transform.position.x,
			this.ground_checker_pos.transform.position.y, this.ground_checker_pos.transform.position.z - radius));
		return col.Length > 1;
	}

	public virtual void Lending()
	{
		this.character_phisic.velocity = Vector3.zero;
	}

	public virtual void Jump()
	{
		//character.GetComponent<Collider>().enabled = false;
		this.character_phisic.AddForce(new Vector3(character.transform.forward.x * jump_force.x
			,character.transform.up.y * jump_force.y,0),ForceMode.Impulse);
	}
	public virtual void PlayTrick()
	{
		if (this.GroundChecker(0.4f))
		{
			this.eventGeter.jump_method = this.Jump;
			this.tricks_anims.Play(this.trick_name);
		}
	}
	public virtual void Rotate()
	{
		this.rotate_anims.Play("Rotate_forward");
	}
	public void rotate(float x,float y,float z)
	{
		this.character.transform.rotation = Quaternion.Euler(new Vector3(x,y,z));
	}


	public void Monkey()
	{
		  //Init();

		     
		  this.jump_force = new Vector2(300,20);
		  this.trick_name = "Monkey";
		  this.eventGeter.jump_method = this.Jump;

		if ( (GroundChecker(0.4f))) 
			{
				print (Con_Of_Monkey);
				this.tricks_anims.SetBool("run", false);
				this.eventGeter.jump_method = this.Jump;
				this.tricks_anims.Play(this.trick_name);
			}



	}




}


///////////////////////////      Triegger Action

