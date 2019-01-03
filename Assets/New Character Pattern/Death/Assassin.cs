using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin
{
    private Death death;

    public Assassin(TricksData tricksData)
    {
        //Debug.Log(tricksData.getCharacter());
        this.death = tricksData.getCharacter().GetComponent<Death>();
        
    }


    public void kill()
    {
        //Debug.Log(this.eventGeter);
        this.death.isDeath = true;
    }

}
