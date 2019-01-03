
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float X;
    private float Y;
    public float andriod_sensevity;
    public float editor_sensevity;
    private float sensevity;
    private bool can_move = true;
    private string buf;
    public bool objectSellected = false;
    public float speed = 3f;

    private void AndroidAlgorithm()
    {
        sensevity = andriod_sensevity;
        X = -Input.GetTouch(0).deltaPosition.x;
        //-Input.GetAxis("Mouse X") * sensevity;
        Y = -Input.GetTouch(0).deltaPosition.y;
        // -Input.GetAxis("Mouse Y") * sensevity;
        this.transform.position += new Vector3(X, Y, 0) * Time.deltaTime;
        X = Y = 0;
    }

    private void EditorAlgorithm()
    {
        sensevity = editor_sensevity;
        //X = -Input.GetTouch(0).deltaPosition.x;
        X = -Input.GetAxis("Mouse X") * sensevity;
        // Y = -Input.GetTouch(0).deltaPosition.y;
        Y =  -Input.GetAxis("Mouse Y") * sensevity;
        this.transform.position += new Vector3(X, Y, 0) * Time.deltaTime;
        X = Y = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && (can_move))
        {
            #if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                AndroidAlgorithm();
            #else
                EditorAlgorithm();
            #endif
        }
    }
    public void CanMove()
    { can_move = true; }
    public void CantMove()
    { can_move = false; }
    public bool GetMoveble()
    { return can_move; }

    public void CameraForwardMove()
    {
        if (this.transform.position.z < -6.2f)
            this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }
    public void CameraBackMove()
    {
        if (this.transform.position.z > -50f)
            this.transform.position -= this.transform.forward * speed * Time.deltaTime;
    }
}
