using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfoLvl : MonoBehaviour
{
    public Text txt;
    public string lvlName;
    public int score_is_now = 0;

    private void Awake()
    {
        txt = this.GetComponent<Text>();
        score_is_now = PlayerPrefs.GetInt("Parcour_"+lvlName);
        txt.text = "Score : " + score_is_now + txt.text;
    }

}
