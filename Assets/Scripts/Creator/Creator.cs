using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public Transform build;
    private void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,100,100),"build"))
        {
        }
    }
}
