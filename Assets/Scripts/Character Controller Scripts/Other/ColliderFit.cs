using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFit : MonoBehaviour
{
    public bool fit = false;
    private CapsuleCollider capsule;
    [SerializeField]
    private GameObject toe_L_end;
    [SerializeField]
    private GameObject spine_006_end;
    private float start_height;

    private void Awake()
    {
        capsule = this.GetComponent<CapsuleCollider>();
        start_height = capsule.height;
    }
    private void FixedUpdate()
    {
        if (fit)
        {
            capsule.height = Vector3.Distance(new Vector3(this.toe_L_end.transform.position.x, this.toe_L_end.transform.position.y, 0), 
                new Vector3(this.spine_006_end.transform.position.x, this.spine_006_end.transform.position.y, 0));
        }
        else
        {
            capsule.height = start_height;
        }
    }
}
