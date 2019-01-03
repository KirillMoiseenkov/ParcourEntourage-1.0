using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public LayerMask lm;

    private void Awake()
    {
        lm = 1 << LayerMask.NameToLayer("Default");
    }

    private void Update()
    {
    }
}
