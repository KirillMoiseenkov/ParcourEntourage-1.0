using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private MainScoreClass mainScoreClass;
    public GameObject winMenu;
    public GameObject notWinMenu;

    private void Awake()
    {
        mainScoreClass =
            GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<MainScoreClass>();
    }

    private void ShowWin()
    {
        Time.timeScale = 0;
        notWinMenu.SetActive(false);
        winMenu.SetActive(true);
    }

    private void ShowNotWin()
    {
        notWinMenu.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "rot")
        {
            if (mainScoreClass.GetScoreCount() >= mainScoreClass.max_score_in_level)
                ShowWin();
            else
                ShowNotWin();
        }

    }
}
