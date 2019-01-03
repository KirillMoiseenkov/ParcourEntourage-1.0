using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterMain : MonoBehaviour
{
	
    public int score = 0;
    [SerializeField]
    private float graund_checker_radius;
    public Tricks tricks;

	private TrickElement forwardFlip;
    private Running running;
	private TakeTheGroup Take_The_Group;
    private Rondate rondate;
    private Screw screw;
    private Flyag flyag;
    private BackFlip backFlip;
    private Arabh arabh;
    private Blansh blansh;
    private SideFlip sideFlip;
	private Falling falling;
	//private TriggerAction TriggerMove;
	private SimpleJump Jumping;
	private Monkey monkey;
	public Animator tricks_anims;
    public string new_action;
	public Vector2 force;
	private const string TTG = "s-9-91";
	private const string Jumping_name = "s-9-9";
	private const string Monkey_name = "s9";
    private const string forward_flip_name = "s1199";
    private const string rondate_flip_name = "s1199-1";
    private const string flyag_flip_name = "s-9-9119";
    private const string back_flip_name = "s-1-199";
    private const string arabh_flip_name = "s11999";
    private const string screw_flip_name = "s1199-1-1";
    private const string blansh_flip_name = "s-1-1999";
    private const string side_flip_name = "s-9-911";
    private const string to_left = "s-1-1";
    private const string to_right = "s11";
    private Camera cam;
    private bool is_grounded = false;
	private bool FallingOrRunnning;
    public float move_speed;
    [SerializeField]
    private Vector3 camera_offset;
    [SerializeField]
    private ColliderFit colliderFit;
    private Animator animator;
    private GameObject player;
    private bool is_played_no_jump_anima;
    private string last_anima;

    private Queue<string> tricks_queue = new Queue<string>();

    public void action_geter(string action)
    {
        this.tricks_queue.Enqueue(action);
    }

    private void CheckOnBackPosition()
	{
		this.is_played_no_jump_anima = this.animator.GetCurrentAnimatorStateInfo(0).IsName(rondate.trick_name);

		if (this.is_played_no_jump_anima)
            running.Run();

		is_grounded = tricks.GroundChecker(graund_checker_radius);
		colliderFit.fit = !is_grounded;
	}

	private void CheckOnFalling()
	{
		if (!tricks.GroundChecker (0.4f)  && (!tricks.eventGeter.anima_is_play 
            || this.animator.GetCurrentAnimatorStateInfo (0).IsName ("run") ) )
        {
		    tricks_anims.SetBool ("Falling", true);
	        falling.PlayTrick ();
		    FallingOrRunnning = true;
		}
		
		if(tricks.GroundChecker (0.4f))
		{
			tricks_anims.SetBool ("Falling", false);
			FallingOrRunnning = false;
		}	
	}

	private void CleanTheQueue()
    {   
		while (tricks_queue.Count != 0)
        {		
			tricks_queue.Dequeue ();
		}
	}

	private void MakeMoveOnTheFalling()
	{
		if (tricks_queue.Count == 0) {
			
			if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Falling"))
				last_anima = "";
		}
        else
        {			
			if ((!tricks.eventGeter.anima_is_play || this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Falling")))
            {
				switch (tricks_queue.Peek ())
                {
				    case TTG:
					    new_action = "";
					    last_anima = tricks_queue.Dequeue ();
					    break;

				    default:					
					    last_anima = tricks_queue.Dequeue ();
					    break;
				}
			} 
		}

	}

	private void MakeMoveOnTheGround()
	{
        if (tricks_queue.Count == 0)
        {
            running.PlayTrick();
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
                last_anima = "";
        }
        else
        {
            if ((!tricks.eventGeter.anima_is_play || this.animator.GetCurrentAnimatorStateInfo(0).IsName("run")))
                switch (tricks_queue.Peek())
                {
                    case Monkey_name:
                        monkey.PlayTrick();
                        last_anima = tricks_queue.Dequeue();
                        break;

                    case Jumping_name:
                        Jumping.PlayTrick();
                        last_anima = tricks_queue.Dequeue();
                        break;

                    case forward_flip_name:
                        
                        forwardFlip.playTrick();
                        new_action = "";
                        tricks.Lending();
                        last_anima = tricks_queue.Dequeue();
                        break;

                    case rondate_flip_name:
                        rondate.PlayTrick();
                        new_action = "";
                        last_anima = tricks_queue.Dequeue();
                        break;

                    case flyag_flip_name:
                        flyag.PlayTrick();
                        new_action = "";
                        last_anima = tricks_queue.Dequeue();
                        break;

                    case back_flip_name:
                        if (last_anima == rondate_flip_name || last_anima == back_flip_name)
                        {
                            backFlip.PlayTrick();
                            new_action = "";
                            tricks.Lending();
                            last_anima = tricks_queue.Dequeue();
                        }
                        else
                        {
                            tricks_queue.Dequeue();
                        }
                        break;

                    case screw_flip_name:
                        if (last_anima == rondate_flip_name || last_anima == back_flip_name)
                        {
                            screw.PlayTrick();
                            new_action = "";
                            tricks.Lending();
                            last_anima = tricks_queue.Dequeue();
                        }
                        else
                        {
                            tricks_queue.Dequeue();
                        }
                        break;

                    case arabh_flip_name:
                        arabh.PlayTrick();
                        new_action = "";
                        tricks.Lending();
                        last_anima = tricks_queue.Dequeue();
                        break;

                    case blansh_flip_name:
                        if (last_anima == rondate_flip_name || last_anima == back_flip_name)
                        {
                            blansh.PlayTrick();
                            new_action = "";
                            tricks.Lending();
                            last_anima = tricks_queue.Dequeue();
                        }
                        else
                        {
                            tricks_queue.Dequeue();
                        }
                        break;

                    case side_flip_name:
                        sideFlip.PlayTrick();
                        new_action = "";
                        tricks.Lending();
                        last_anima = tricks_queue.Dequeue();
                        break;

                    case to_left:
                        if (tricks.GroundChecker(0.4f))
                            tricks.rotate(0, -90, 0);
                        new_action = "";
                        last_anima = tricks_queue.Dequeue();
                        break;

                    case to_right:
                        if (tricks.GroundChecker(0.4f))
                            tricks.rotate(0, 90, 0);
                        new_action = "";
                        last_anima = tricks_queue.Dequeue();
                        break;

                    default:
                        last_anima = tricks_queue.Dequeue();
                        break;
                }
        }
	}

}
