using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmallMeths : MonoBehaviour
{
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    //temp
    public void RestartSceene()
    {
        Tricks.Con_Of_Monkey = false;
        Tricks.Con_Of_ShotWallRun = false;
        Tricks.Con_Of_ShotWallRun_Shadow = false;
        Tricks.Con_Of_WallRun = false;
        Tricks.Con_Of_WallRun_Shadow = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CloseApp()
    {
        Application.Quit();
    }
    //
}
