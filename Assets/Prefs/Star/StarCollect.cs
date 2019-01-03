using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{
    private MainScoreClass mainScoreClass;

    private void Awake()
    {
        mainScoreClass = 
            GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<MainScoreClass>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.tag);
        if((other.gameObject.tag == "rot") || (other.gameObject.tag == "body"))
        {
            //print("star : player detected like a " + other.gameObject.tag +"!");
            mainScoreClass.AddScore(1);
            int scoreCount = mainScoreClass.GetScoreCount();
            if (scoreCount > PlayerPrefs.GetInt("Parcour_"+Application.loadedLevelName))
                PlayerPrefs.SetInt("Parcour_"+Application.loadedLevelName,scoreCount);
            Destroy(this.gameObject);
        }
    }
}
