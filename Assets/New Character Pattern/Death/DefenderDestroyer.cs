using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderDestroyer
{
    private EventGeter eventGeter;

    public DefenderDestroyer(TricksData tricksData)
    {
        this.eventGeter = tricksData.getEventGeter();
    }

    public DefenderDestroyer(EventGeter eventGeter)
    {
        this.eventGeter = eventGeter;
    }

    public void destroy()
    {
        this.eventGeter.IsDangerBegin();
    }

    public void reestablish()
    {
        this.eventGeter.IsDangerEnd();
    }

}
