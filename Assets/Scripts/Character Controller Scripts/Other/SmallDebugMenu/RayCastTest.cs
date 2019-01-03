using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    public class Capsule
    {
        public Vector3 top, buttom;
        public float rad;

        public Capsule(Vector3 center, float rad, float height,float x_offset)
        {
            top = new Vector3(center.x + x_offset, center.y + height/2);
            buttom = new Vector3(center.x + x_offset, center.y - height/2);
        }
    }

    //private RaycastHit raycast_hit_inf;
    //private Collider[] raycasted_col;
    private bool touchTheWall = false;
    RaycastHit hit;
    private Collider[] col;
    public void Update()
    {
        col = Physics.OverlapSphere(this.transform.position, 0.55f);
        if (col.Length > 1)
            print("detected!");
        else
            print("not detected!");

        /*Capsule StartCapsule = new Capsule(this.transform.position, 0.55f, 2f, 0f);
        if (Physics.CapsuleCast(StartCapsule.top, StartCapsule.buttom,
                        StartCapsule.rad, transform.up, out hit))
        {
            print("Detected!");
        }
        */
    }
}
