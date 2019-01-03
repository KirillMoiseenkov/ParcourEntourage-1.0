using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethDetected : MonoBehaviour
{
    private Death death;
    private GameObject character;
    public GameObject blood_pref;
    private bool is_first_hit = true;
    private Rigidbody body_physics;

    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("character");
        death = character.GetComponent<Death>();
        body_physics = this.GetComponent<Rigidbody>();
    }
    private GameObject buf_go;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "location")
        {
            if(is_first_hit)
            {
                buf_go = Instantiate(blood_pref, this.transform.position, Quaternion.identity);
                buf_go.transform.SetParent(this.transform);
                is_first_hit = false;
            }
            //body_physics.AddForce(-300 * character.transform.forward);
            death.isDeath = true;
        }
    }
}
