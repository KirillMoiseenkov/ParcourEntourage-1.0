using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnima : MonoBehaviour
{
    public float speed = 2.0f;

    private void Update()
    {
        transform.Rotate(0, 0, speed);
    }
}
