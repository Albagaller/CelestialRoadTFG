using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAviso : MonoBehaviour
{
    public GameObject aviso;
    public Autowalk walk;
    public GameObject panel;
   // CambioVR cambioVR;

    // Start is called before the first frame update
    void Start()
    {
        // cambioVR = GameObject.Find("CambioVR").GetComponent(typeof(CambioVR)) as CambioVR;
       // cambioVR.ToggleVR();
        walk = GameObject.Find("Player").GetComponent<Autowalk>();
        GlobalVariables.GameIni = true;
    }

    public void BtnOK()
    {
        PlayClick();

        aviso.SetActive(false);
        GlobalVariables.GameIni = false;

        if (!GlobalVariables.GameIsPause)
        {
            walk.enabled = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        walk.enabled = false;
        GlobalVariables.GameIni = true;
        panel.SetActive(true);
    }



    void PlayClick()
    {
        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().clip = Resources.Load("button_click") as AudioClip;
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().Play();
    }
}
