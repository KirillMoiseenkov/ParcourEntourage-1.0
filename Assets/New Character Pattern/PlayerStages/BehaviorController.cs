using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    private IPlayerStage playerBehavior;
    private ElementBuilder elementBuilder;
    private ElementBaker elementBaker;
    private TricksData trickData;

    private IPlayerStage playerBehaviorFall;
    private IPlayerStage playerBehaviorGrounded;


    private Dictionary<string, TrickElement> fall_tricks_list;
    private Dictionary<string, TrickElement> grounded_tricks_list;
    private Dictionary<string, TrickElement> tricks_list;


    public BehaviorController(TricksData tricksData)
    {
        this.tricks_list = new Dictionary<string, TrickElement>();

        this.fall_tricks_list = new Dictionary<string, TrickElement>();
        this.grounded_tricks_list = new  Dictionary<string, TrickElement>();


        this.elementBaker = new ElementBaker();
        this.trickData = tricksData;
        //GROUNDED ELEMENTS
        this.elementBuilder = new ElementBuilderAtTheGround(tricksData);      

        //froward flip
        this.elementBuilder.createElement();
        this.elementBuilder.setAnimaSpeed(0.70f);
        this.elementBuilder.setRotateSpeed(0.8f);
        this.elementBuilder.setJumpForce(new Vector2(65, 275));
        this.elementBuilder.setRotateAnimName("Rotate_forward");
        this.elementBuilder.setTrickName("forward_flip");

        this.grounded_tricks_list.Add("forward_flip", this.elementBaker.bake(this.elementBuilder));


        //arabh
        this.elementBuilder.createElement();
        this.elementBuilder.setAnimaSpeed(0.9f);
        this.elementBuilder.setRotateSpeed(0.8f);
        this.elementBuilder.setJumpForce(new Vector2(50, 350));
        this.elementBuilder.setRotateAnimName("Rotate_forward");
        this.elementBuilder.setTrickName("arabh_first_stage");

        this.grounded_tricks_list.Add("arabh_first_stage", this.elementBaker.bake(this.elementBuilder));


        //this.tricks_list.Add(this.elementBaker.bake(this.elementBuilder));

        //this.grounded_tricks_list.AddRange(tricks_list);
        ////

        ////FALLING ELEMENTS
        //this.elementBuilder = new ElementBuilderInTheFalling(tricksData);

        ////ff in falling
        this.elementBuilder.createElement();
        this.elementBuilder.setAnimaSpeed(1f);
        this.elementBuilder.setRotateSpeed(1f);
        this.elementBuilder.setJumpForce(new Vector2(0, 0));
        this.elementBuilder.setRotateAnimName("Rotate_forward");
        this.elementBuilder.setTrickName("ForwardFlip_F");


        this.fall_tricks_list.Add("ForwardFlip_F",this.elementBaker.bake(this.elementBuilder));

        this.setBehaviorFall();

        playerBehaviorFall = new PlayerFallBehavior(this.trickData);
        playerBehaviorGrounded = new PlayerGroundBehavior(this.trickData);

        playerBehaviorFall.addTrickRange(fall_tricks_list);
        playerBehaviorGrounded.addTrickRange(grounded_tricks_list);

    }

    public void setBehavior()
    {
    }

    public void setBehaviorFall()
    {
        this.playerBehavior = playerBehaviorFall;
    }

    public void setBehaviorGround()
    {
        this.playerBehavior = playerBehaviorGrounded;
    }

    public void addElementToQueue(string trickName)
    {
        TrickElement element =  this.playerBehavior.getElementFromTrickDictionary(trickName);
        this.playerBehavior.addElementToQueue(element);
    }

    public void execute()
    {
        this.playerBehavior.execute();
    }

}
