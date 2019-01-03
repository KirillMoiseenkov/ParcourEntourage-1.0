using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker:MonoBehaviour
{
    public GameObject graundCheckerObject;
    //private TricksData trickData;
    //private int layerMask;

    public GroundChecker(TricksData td)
    {
        //this.trickData = td;
        this.graundCheckerObject = td.getGroundChecker();
        //layerMask = trickData.getLayerMask();
    }

    public bool isGrounded(float ray_height)
    {
        //Debug.DrawRay(this.graundCheckerObject.transform.position, -this.graundCheckerObject.transform.up, 
        //Color.red, ray_height);

        bool b = Physics.Raycast(this.graundCheckerObject.transform.position, -this.graundCheckerObject.transform.up,
            ray_height);//,layerMask);

        print(b);

        return b;
    }
}
