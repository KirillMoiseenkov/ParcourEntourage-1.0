using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBuilderAtTheGround : ElementBuilder
{
   

    public ElementBuilderAtTheGround(TricksData tricksData) : base(tricksData) { }

    public void jump()
    {
        GameObject chara = this.tricksData.getCharacter();

        this.tricksData.getCharacterPhisic().AddForce(new Vector3(chara.transform.forward.x * jump_force.x
            , chara.transform.up.y * jump_force.y, 0), ForceMode.Impulse);
    }

    public void rotate()
    {
        this.tricksData.getRotateAnims().Play(this.rotate_anim_name);
    }
}
