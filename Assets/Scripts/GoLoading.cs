using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLoading : MonoBehaviour
{
    public GameObject loading;
    public int lvl;



    public void saveNumLevel()
    {
        PlayClick();
        GlobalVariables.nivelActual = lvl;
        loading.SetActive(true);

    }

    public void next()
    {
        PlayClick();
        loading.SetActive(true);
    }


    void PlayClick()
    {
        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().clip = Resources.Load("button_click") as AudioClip;
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().Play();
    }
}
