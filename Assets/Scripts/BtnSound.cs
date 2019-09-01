using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSound : MonoBehaviour
{

    public GameObject btn;

    void Start()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
        {
            btn.SetActive(true);
            AudioListener.pause = true;

        }
        else
        {
            btn.SetActive(false);
            AudioListener.pause = false;

        }

    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;

        if (AudioListener.pause == true) {
            btn.SetActive(true);
            PlayerPrefs.SetInt("mute", 1);
        }
        else
        {
            btn.SetActive(false);
            PlayerPrefs.SetInt("mute", 0);

        }
    }
}
