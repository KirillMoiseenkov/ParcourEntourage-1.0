using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementBuilder
{
    protected Vector3 jump_force;
    protected TricksData tricksData;

    protected TrickElement trickElement;

    protected float rotateSpeed;
    protected string trick_name;
    protected string rotate_anim_name;
    protected float animaSpeed;

    public ElementBuilder(TricksData tricksData)
    {
        this.tricksData = tricksData;
    }



    public void createElement()
    {
        this.trickElement = new TrickElement(this.tricksData);
    }


    public void setJumpForce(Vector2 jumpForce)
    {
        this.trickElement.setJumpForce(jumpForce);
    }

    public TrickElement getTrickElement()
    {
        return this.trickElement;
    }

    public void setRotateSpeed(float speed)
    {
        this.trickElement.setRotateSpeed(speed);
    }

    public void setTrickName(string trick_n)
    {
        this.trickElement.setTrickName(trick_n);
    }

    public void setRotateAnimName(string ra_name)
    {
        this.trickElement.setRotateAnimName(ra_name);
    }

    public void setAnimaSpeed(float speed)
    {
        this.trickElement.setAnimaSpeed(speed);
    }

    public override string ToString()
    {
        return "name, force, anim, type, speed \n" +
               trick_name +
               jump_force +
               rotate_anim_name +
               animaSpeed;
    }
}
