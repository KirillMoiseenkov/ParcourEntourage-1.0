using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScoreClass : MonoBehaviour
{
    public int max_score_in_level;
    private int score;
    private Text score_label;
    private InfoAboutLvl inf;

    public void AddScore(int n)
    {
        this.score += n;
    }
    public int GetScoreCount()
    {
        return score;
    }

    public void Restart()
    {
        int lvl_name = Application.loadedLevel;
        Application.LoadLevel(lvl_name);
    }

    public void GoToLevel(int lvl)
    {
        Application.LoadLevel(lvl);
    }

    private void Awake()
    {
        this.inf = Camera.main.gameObject.GetComponent<InfoAboutLvl>();
        if (inf != null)
            this.max_score_in_level = this.inf.max_score;
        else
            this.max_score_in_level = 1;
        this.score_label = this.GetComponent<Text>();
        score = 0;
    }

    private void Update()
    {
        if (this.max_score_in_level > 0)
            this.score_label.text = "Your score: " + score + "/" + max_score_in_level;
        else
            this.score_label.text = "";
    }
}
