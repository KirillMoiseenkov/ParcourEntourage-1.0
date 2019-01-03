using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashtabBtns : MonoBehaviour
{
    public bool isPositiv;
    private CameraMove cam_move;

    private void Awake()
    {
        cam_move = Camera.main.GetComponent<CameraMove>();
    }

    private void OnMouseDrag()
    {
        if (isPositiv) cam_move.CameraForwardMove();
        else cam_move.CameraBackMove();
    }
}
