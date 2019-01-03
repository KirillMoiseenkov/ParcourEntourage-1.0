using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForLoadedLevel : MonoBehaviour
{
    private void Start ()
    {
        Application.LoadLevelAsync(MainMenu.lavelLoadReqest);
	}
}
