using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBuilderInTheFalling : ElementBuilder
{
    public ElementBuilderInTheFalling(TricksData tricksData) : base(tricksData) { }

    public void rotate()
    {
        this.tricksData.getRotateAnims().Play(this.rotate_anim_name);
    }
}
