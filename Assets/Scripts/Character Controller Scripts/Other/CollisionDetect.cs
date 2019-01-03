using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public bool isDetect = false;

    
    //void OnCollider

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "location")
            isDetect = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "location")
            isDetect = false;
    }
}
