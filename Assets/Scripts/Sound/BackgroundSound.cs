using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public GameObject audioSource;

    private void Awake()
    {
        if(!GameObject.Find("BackgroundSound"))
        {
            GameObject audio_source = Instantiate(audioSource, Vector3.zero, Quaternion.identity);
            audio_source.name = "BackgroundSound";
            if(PlayerPrefs.GetInt("Parcour_sound_enable") == 0)
                audio_source.GetComponent<AudioSource>().enabled = true;
            else
                audio_source.GetComponent<AudioSource>().enabled = false;
            DontDestroyOnLoad(audio_source);
        }
    }
}
