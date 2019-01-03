using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathTrigger : MonoBehaviour
{
    public EventGeter event_geter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "location")
        {
            event_geter.IsDangerBegin();
            event_geter.death.isDeath = true;
        }
            
    }
}
